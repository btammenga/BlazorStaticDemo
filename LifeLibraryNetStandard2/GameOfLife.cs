using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeLibraryNetStandard2
{
    public delegate void HeartbeatEventHandler(object sender, HeartbeatEventArgs args);
    public class GameOfLife
    {
        private List<Cell> _cells;
        private readonly int _xSize;
        private readonly int _ySize;
        private readonly int _ticks;
        private int _tick = 0;
        private DateTime _startLiving;

        public event HeartbeatEventHandler Heartbeat;

        public List<Cell> Cells 
        {
            get
            {
                return _cells;
            }
            private set
            {

            }
        } 
        
        public GameOfLife(int xSize, int ySize, int ticks)
        {
            _xSize = xSize;
            _ySize = ySize;
            _ticks = ticks;

            InitializeCellGrid();         
        }

        public void Live(int heartbeatIntervalMilliSec)
        {
            _startLiving = DateTime.Now;
            for (_tick = 0; _tick < _ticks; _tick++)
            {
                CalculateLivingNeighbours();
                PlayGod();

                Heartbeat?.Invoke(this, new HeartbeatEventArgs(_tick, _startLiving));

                if (heartbeatIntervalMilliSec > 0)
                {
                    System.Threading.Thread.Sleep(heartbeatIntervalMilliSec);
                }
            }
        }

        private void InitializeCellGrid()
        {
            _cells = new List<Cell>();
            // Create Cell Collection
            for (int y = 0; y < _ySize; y++)
            {
                for (int x = 0; x < _xSize; x++)
                {
                    Cell cell = new Cell()
                    {
                        XPosition = x + 1,
                        YPosition = y + 1
                    };
                    Cells.Add(cell);
                }
            }
            // Fill Cell Neighbourslist
            AddNeighbours();
        }

        private void AddNeighbours()
        {
            foreach (var cell in Cells)
            {
                cell.Neighbours = CreateNeighbourList(cell);
            }
        }

        private List<Cell> CreateNeighbourList(Cell cell)
        {
            int xStart = cell.XPosition > 1 ? cell.XPosition - 1 : 1;
            int xEnd = cell.XPosition < _xSize ? cell.XPosition + 1 : _xSize;
            int yStart = cell.YPosition > 1 ? cell.YPosition - 1 : 1;
            int yEnd = cell.YPosition < _ySize ? cell.YPosition + 1 : _ySize;

            var result = Cells.Where(c => c.XPosition >= xStart)
                              .Where(c => c.XPosition <= xEnd)
                              .Where(c => c.YPosition >= yStart)
                              .Where(c => c.YPosition <= yEnd).ToList();
            result.Remove(cell);
            return result;
        }             

        private void PlayGod()
        {
            foreach (var cell in Cells)
            {
                SetCellIsAlive(cell);
            }
        }

        private void SetCellIsAlive(Cell cell)
        {
            if (cell.IsAlive)
            {
                if (cell.LivingNeigbours < 2)
                {
                    cell.IsAlive = false;
                }
                else if (cell.LivingNeigbours > 3)
                {
                    cell.IsAlive = false;
                }

                //switch (cell.LivingNeigbours)
                //{
                //    case  < 2:
                //        cell.IsAlive = false;
                //        break;
                //    case > 3:
                //        cell.IsAlive = false;
                //        break;
                //}
            }
            else
            {
                if (cell.LivingNeigbours ==3)
                {
                    cell.IsAlive = true;
                }
            }
        }

        private void CalculateLivingNeighbours()
        {
            foreach (var cell in Cells)
            {
                cell.LivingNeigbours = cell.Neighbours.Where(n => n.IsAlive).Count();
            }
        }      

    }
}
