using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinesweeperApp.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private static GameData _game;

        [HttpGet("[action]")]
        public GameData GetFields()
        {
            var rnd = new Random();
            var width = 10;
            var height = 10;
            var fields = new Field[width,height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var f = new Field();
                    f.Number = rnd.Next(0, 2).ToString();
                    fields[i, j] = f;
                }
            }
            
            var gd = new GameData();
            gd.Fields = fields;
            gd.Width = width;
            gd.Height = height;
            _game = gd;
            return gd;
        }

        public class OpenFieldRequest
        {
            public int x;
            public int y;
        }

        [HttpPost]
        [Route("OpenField")]
        public IActionResult OpenField(int x, int y)//OpenFieldRequest reqeust)//int x, int y)
        {
            //_game.Fields[x, y].Open = true;
            //return _game;
            return Json(_game); 
        }

        [HttpPost]
        [Route("OpenField2")]
        public IActionResult OpenField2(string text)//OpenFieldRequest reqeust)//int x, int y)
        {
            _game.TestText = text;
            //_game.Fields[x, y].Open = true;
            //return _game;
            return Json(_game); 
        }
        
        [HttpPost]
        [Route("OpenField3")]
        public GameData OpenField3([FromBody]string text)//OpenFieldRequest reqeust)//int x, int y)
        {
            _game.TestText = text;
            //_game.Fields[x, y].Open = true;
            //return _game;
            return _game; 
        }

        public class GameData
        {
            public string TestText { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public Field[,] Fields { get; set; }
        }

        public class Field
        {
            public string Number { get; set; }
            public bool Open { get; set; }
        }
    }
}
