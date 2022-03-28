using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLibraryNetStandard2
{
    public class Seed
    {
        private readonly List<Cell> _cells;

        public Seed(List<Cell> Cells)
        {
            _cells = Cells;
        }

        private static void SetAlive(List<Cell> cellSelection)
        {
            foreach (var cell in cellSelection)
            {
                cell.IsAlive = true;
            }
        }
        public void SeedCell(int x, int y)
        {
            var cellSelection = _cells.Where(s => s.XPosition == x)
                         .Where(s => s.YPosition == y).ToList();
            SetAlive(cellSelection);
        }
        public void SeedBlock(int x, int y)
        {
            SeedCell(x, y);
            SeedCell(x + 1, y);
            SeedCell(x, y + 1);
            SeedCell(x + 1, y + 1);
        }

        public void SeedHorBlinker(int x, int y)
        {
            var cellSelection = _cells.Where(s => s.XPosition >= x)
                         .Where(s => s.XPosition < x + 3)
                         .Where(s => s.YPosition == y).ToList();

            SetAlive(cellSelection);
        }

        public void SeedVerBlinker(int x, int y)
        {
            var cellSelection = _cells.Where(s => s.XPosition == x)
                         .Where(s => s.YPosition >= y)
                         .Where(s => s.YPosition < y + 3).ToList();

            SetAlive(cellSelection);
        }

        public void SeedToad(int x, int y)
        {
            SeedHorBlinker(x + 1, y);
            SeedHorBlinker(x, y + 1);
        }

        public void SeedGlider(int x, int y)
        {
            SeedCell(x + 1, y);
            SeedCell(x + 2, y + 1);
            SeedHorBlinker(x, y + 2);
        }

        public void SeedLightWeightSpaceship(int x, int y)
        {
            SeedCell(x, y);
            SeedCell(x + 3, y);
            SeedCell(x + 4, y + 1);
            SeedCell(x, y + 2);
            SeedCell(x + 4, y + 2);
            SeedCell(x + 1, y + 3);
            SeedCell(x + 2, y + 3);
            SeedCell(x + 3, y + 3);
            SeedCell(x + 4, y + 3);
        }


        public void SeedGosperGliderGun(int x, int y)
        {
            SeedCell(x + 24, y);

            SeedCell(x + 22, y + 1);
            SeedCell(x + 24, y + 1);

            SeedCell(x + 12, y + 2);
            SeedCell(x + 13, y + 2);
            SeedBlock(x + 20, y + 2);
            SeedBlock(x + 34, y + 2);

            SeedCell(x + 11, y + 3);
            SeedCell(x + 15, y + 3);

            SeedBlock(x, y + 4);
            SeedVerBlinker(x + 10, y + 4);
            SeedVerBlinker(x + 16, y + 4);
            SeedCell(x + 20, y + 4);
            SeedCell(x + 21, y + 4);

            SeedCell(x + 14, y + 5);
            SeedCell(x + 17, y + 5);
            SeedCell(x + 22, y + 5);
            SeedCell(x + 24, y + 5);

            SeedCell(x + 24, y + 6);

            SeedCell(x + 11, y + 7);
            SeedCell(x + 15, y + 7);

            SeedCell(x + 12, y + 8);
            SeedCell(x + 13, y + 8);

        }

        public void SeedGosperGliderGunRL(int x, int y)
        {
            SeedCell(x + 11, y);

            SeedCell(x + 11, y + 1);
            SeedCell(x + 13, y + 1);

            SeedBlock(x, y + 2);
            SeedBlock(x + 14, y + 2);
            SeedCell(x + 22, y + 2);
            SeedCell(x + 23, y + 2);

            SeedCell(x + 20, y + 3);
            SeedCell(x + 24, y + 3);

            SeedCell(x + 14, y + 4);
            SeedCell(x + 15, y + 4);
            SeedVerBlinker(x + 19, y + 4);
            SeedVerBlinker(x + 25, y + 4);
            SeedBlock(x + 34, y + 4);

            SeedCell(x + 11, y + 5);
            SeedCell(x + 13, y + 5);
            SeedCell(x + 18, y + 5);
            SeedCell(x + 21, y + 5);

            SeedCell(x + 11, y + 6);

            SeedCell(x + 20, y + 7);
            SeedCell(x + 24, y + 7);

            SeedCell(x + 22, y + 8);
            SeedCell(x + 23, y + 8);

        }
    }
}
