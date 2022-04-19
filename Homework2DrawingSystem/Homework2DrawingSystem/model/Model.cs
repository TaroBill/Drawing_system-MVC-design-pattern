using Homework2DrawingSystem.Model;
using Homework2DrawingSystem.Model.Command;
using Homework2DrawingSystem.Model.Shapes;
using Homework2DrawingSystem.Model.States;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2DrawingSystem.Model
{
    public class Model
    {
        public ModelChangedEventHandler ModelChanged
        {
            get; set;
        }
        public delegate void ModelChangedEventHandler();
        private readonly List<IShape> _shapes = new List<IShape>();
        private IState _nowState;
        private readonly CommandManager _commandManager = new CommandManager();
        private readonly GoogleDriveService _service;

        public Model()
        {
            const string APPLICATION_NAME = "Homework2DrawingSystem";
            const string CLIENT_SECRET_FILE_NAME = "Model/clientSecret.json";
            _nowState = StateFactory.GenerateState(StateFactory.StateTypes.Default, this);
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //轉換狀態
        public void ChangeState(StateFactory.StateTypes type)
        {
            _nowState = StateFactory.GenerateState(type, this);
        }

        //按下左鍵
        public void PressedPointer(double locationX, double locationY)
        {
            if (locationX > 0 && locationY > 0)
            {
                _nowState.PressedPointer(locationX, locationY);
            }
        }

        //移動左鍵
        public void MovedPointer(double locationX, double locationY)
        {
            _nowState.MovedPointer(locationX, locationY);
            NotifyModelChanged();
        }

        //放開左鍵
        public void ReleasedPointer(double locationX, double locationY)
        {
            _nowState.ReleasedPointer(locationX, locationY);
            NotifyModelChanged();
        }

        //清除
        public void Clear()
        {
            _shapes.Clear();
            _nowState.RemoveShape();
            NotifyModelChanged();
        }

        //加入回來
        public void AddBack(List<IShape> shapes)
        {
            _shapes.AddRange(shapes);
            NotifyModelChanged();
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (IShape shapes in _shapes)
                shapes.DrawPriorityHigh(graphics);
            foreach (IShape shapes in _shapes)
                shapes.Draw(graphics);
            foreach (IShape shapes in _shapes)
                shapes.DrawPriorityLow(graphics);
            _nowState.Draw(graphics);
        }

        //畫圖
        public void DrawShape(IShape shape)
        {
            _shapes.Add(shape);
            NotifyModelChanged();
        }

        //刪除圖
        public void DeleteShape(IShape shape)
        {
            _shapes.Remove(shape);
            _nowState.RemoveShape(shape);
            NotifyModelChanged();
        }

        //取得輸入座標的shape
        public IShape GetShape(double locationX, double locationY)
        {
            for (int index = _shapes.Count() - 1; index >= 0; index--)
            {
                if (_shapes[index].Contain(locationX, locationY))
                {
                    return _shapes[index];
                }
            }
            return null;
        }

        //尋找shape
        public IShape FindShape(string inputString)
        {
            foreach (IShape shape in _shapes)
            {
                if (shape.IsSame(inputString))
                    return shape;
            }
            return null;
        }

        //儲存到檔案
        public void SaveToFile()
        {
            const string FILE_NAME = "ShapeData.shw";
            try
            {
                StreamWriter streamWriter = new StreamWriter(FILE_NAME, false, Encoding.UTF8);
                foreach (IShape shape in _shapes)
                {
                    streamWriter.WriteLine(shape.Serialize());
                }
                streamWriter.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
        }

        //從檔案讀取
        public void LoadFromFile()
        {
            const char LEFT_QUOTE = '(';
            const string FILE_NAME = "ShapeData.shw";
            try
            {
                IEnumerable<string> lines = File.ReadLines(FILE_NAME);
                Clear();
                foreach (string shape in lines)
                {
                    int shapeDataIndex = shape.IndexOf(LEFT_QUOTE);
                    string shapeType = shape.Substring(0, shapeDataIndex);
                    string shapeData = shape.Substring(shapeDataIndex);
                    IShape shapeInstance = ShapeFactory.GenerateShape(shapeType);
                    shapeInstance.Deserialize(shapeData, this);
                    DrawShape(shapeInstance);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
        }

        //儲存到雲端
        private void SaveToGoogleDrive()
        {
            const string FILE_NAME = "ShapeData.shw";
            const string CONTENT_TYPE = "text/shw;charset=UTF-8";
            try
            {
                List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == FILE_NAME; });
                if (foundFile != null)
                {
                    _ = _service.UpdateFile(FILE_NAME, foundFile.Id, CONTENT_TYPE);
                }
                else
                {
                    _ = _service.UploadFile(FILE_NAME, CONTENT_TYPE);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                //throw new Exception("找不到檔案");
            }
        }

        //從雲端讀取檔案
        public void Load()
        {
            const string FILE_NAME = "ShapeData.shw";
            try
            {
                List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(item => { return item.Title == FILE_NAME; });
                _service.DownloadFile(foundFile, Directory.GetCurrentDirectory());
                LoadFromFile();
                _commandManager.ClearAllCommand();
                NotifyModelChanged();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        //儲存到雲端硬碟
        public async void Save()
        {
            Task saveTask = Task.Run(SaveToFile);
            await saveTask;
            Task saveToDriveTask = Task.Run(SaveToGoogleDrive);
            await saveToDriveTask;
        }

        //通知所有訂閱者model改變了
        public void NotifyModelChanged()
        {
            ModelChanged?.Invoke();
        }

        private IShape _selectedShape;
        public IShape SelectedShape
        {
            get
            {
                return _selectedShape;
            }
            set
            {
                _selectedShape = value;
                NotifyModelChanged();
            }
        }

        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
            }
        }

        public List<IShape> AllShape
        {
            get
            {
                return _shapes;
            }
        }
    }
}
