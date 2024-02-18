using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    //Класс определяет Модель  компьютера, которая  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  
    //объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах 
    //и количеством экземпляров, имеющихся в наличии.
    class PC
    {
        public int Id { get; set; }                 //код
        public string Brande { get; set; }           //марка
        public string ProcType { get; set; }        //тип процессора
        public double ProcGHz { get; set; }          //частота работы процессора
        public int RAM { get; set; }                //объем ОЗУ
        public int SSD { get; set; }                //объем жесткого диска
        public int VideoCard { get; set; }         //объем памяти видеокарты
        public int Price { get; set; }            //стоимость
        public int Kolvo { get; set; }              //количество экземпляров в наличии
    }
}
