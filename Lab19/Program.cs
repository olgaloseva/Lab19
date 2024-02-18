using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    //Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  
    //объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах 
    //и количеством экземпляров, имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.
    //Определить: - все компьютеры с указанным процессором.Название процессора запросить у пользователя;
    //- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
    //- вывести весь список, отсортированный по увеличению стоимости;
    //- вывести весь список, сгруппированный по типу процессора;
    //- найти самый дорогой и самый бюджетный компьютер;
    //- есть ли хотя бы один компьютер в количестве не менее 30 штук?
    {
        static void Main(string[] args)
        {
            List<PC> pcList = new List<PC>
            {
                new PC(){Id=101011, Brande="ASUS", ProcType="Intel Core i5", ProcGHz=2.8, RAM=8, SSD=512, VideoCard=1024, Price=40000, Kolvo=5},
                new PC(){Id=123011, Brande="Acer", ProcType="Intel Core i3", ProcGHz=2.8, RAM=8, SSD=256, VideoCard=1024, Price=35000, Kolvo=7},
                new PC(){Id=101451, Brande="ASUS", ProcType="Intel Core i3", ProcGHz=2.8, RAM=8, SSD=256, VideoCard=512, Price=37999, Kolvo=12},
                new PC(){Id=118011, Brande="ASUS", ProcType="Intel Core i5", ProcGHz=2.8, RAM=8, SSD=512, VideoCard=512, Price=40500, Kolvo=7},
                new PC(){Id=251011, Brande="Aser", ProcType="AMD Ryzen 9", ProcGHz=2.8, RAM=16, SSD=1024, VideoCard=1024, Price=125000, Kolvo=2},
                new PC(){Id=101897, Brande="ASUS", ProcType="Intel Core i5", ProcGHz=2.8, RAM=8, SSD=512, VideoCard=512, Price=66000, Kolvo=13},
                new PC(){Id=101894, Brande="ASUS", ProcType="Intel Core i5", ProcGHz=2.8, RAM=8, SSD=1024, VideoCard=1024, Price=100000, Kolvo=6},
                new PC(){Id=350011, Brande="HP", ProcType="AMD Ryzen", ProcGHz=2.8, RAM=16, SSD=1024, VideoCard=1024, Price=180000, Kolvo=13},
                new PC(){Id=105611, Brande="HP", ProcType="Intel Core i7", ProcGHz=2.8, RAM=16, SSD=1024, VideoCard=1024, Price=160000, Kolvo=5},
                new PC(){Id=871011, Brande="DEXP", ProcType="Intel Celeron N4020", ProcGHz=1.1, RAM=8, SSD=128, VideoCard=512, Price=25000, Kolvo=35},
            };

            Console.WriteLine("Выберите тип процессора: ");
            Console.WriteLine("1 - Intel Core i7");
            Console.WriteLine("2 - Intel Core i5");
            Console.WriteLine("3 - Intel Core i3");
            Console.WriteLine("4 - Intel Celeron N4020");
            Console.WriteLine("5 - AMD Ryzen 9");
            Console.WriteLine("6 - AMD Ryzen");

            string procType = "";
            int type=Convert.ToInt32(Console.ReadLine());

            switch (type)
            {
                case 1:
                    procType = "Intel Core i7";
                    break;
                case 2:
                    procType = "Intel Core i5";
                    break;
                case 3:
                    procType = "Intel Core i3";
                    break;
                case 4:
                    procType = "Intel Celeron N4020";
                    break;
                case 5:
                    procType = "AMD Ryzen 9";
                    break;
                case 6:
                    procType = "AMD Ryzen";
                    break;
            }
            List<PC> pcList1 = pcList.Where(x => x.ProcType == procType).ToList();
            Console.WriteLine($"Компьютеры с типом процессора {procType}: ");
            Print(pcList1);

            Console.Write("Введите объем ОЗУ: ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<PC> pcList2 = pcList.Where(x => x.RAM >= ram).ToList();
            Console.WriteLine($"Компьютеры с объемом ОЗУ не менее {ram} Гб:");
            Print(pcList2);

            List<PC> pcList3 = pcList.OrderBy(x => x.Price).ToList();
            Console.WriteLine("Компьютеры по возрастанию цены:");
            Print(pcList3);

            Console.WriteLine("Компьютеры по типу процессора:");
            IEnumerable<IGrouping<string, PC>> pcList4 = pcList.GroupBy(x => x.ProcType);
           
            foreach (IGrouping<string, PC> group in pcList4)
            {
                Console.WriteLine(group.Key);
                foreach (PC pc in group)
                {
                    Console.WriteLine($"{pc.Id} {pc.Brande} {pc.ProcType} {pc.ProcGHz} {pc.RAM} {pc.SSD} {pc.VideoCard} {pc.Price} {pc.Kolvo}");
                }
            }
            Console.WriteLine();

            PC pc5 = pcList.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine("Самый дорогой компьютер:");
            Console.WriteLine($"{pc5.Id} {pc5.Brande} {pc5.ProcType} {pc5.ProcGHz} {pc5.RAM} {pc5.SSD} {pc5.VideoCard} {pc5.Price} {pc5.Kolvo}");

            PC pc6 = pcList.OrderByDescending(x => x.Price).LastOrDefault();
            Console.WriteLine("Самый бюджетный компьютер:");
            Console.WriteLine($"{pc6.Id} {pc6.Brande} {pc6.ProcType} {pc6.ProcGHz} {pc6.RAM} {pc6.SSD} {pc6.VideoCard} {pc6.Price} {pc6.Kolvo}");
            Console.WriteLine();

            bool nalichie = pcList.Any(x => x.Kolvo >= 30);
            if (nalichie)
                Console.WriteLine("Да, есть в наличие компьютер в количестве не менее 30 штук.");
            else
                Console.WriteLine("Нет в наличие компьютеров в количестве не менее 30 штук.");
            Console.ReadKey();
        }

        static void Print(List<PC> pcList)
        {
            foreach (PC pc in pcList)
            {
                Console.WriteLine($"{pc.Id} {pc.Brande} {pc.ProcType} {pc.ProcGHz} {pc.RAM} {pc.SSD} {pc.VideoCard} {pc.Price} {pc.Kolvo}");
            }
            Console.WriteLine();
        }
    }
}
