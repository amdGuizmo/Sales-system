using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Sales_system.Library
{
    public class Paginador<T>
    {
        private List<T> _dataList;
        private TextBlock _textBlock;
        private static int maxReg, _reg_por_pagina, pageCount, numPagi = 1;

        public Paginador(List<T> dataList, int reg_por_pagina, TextBlock textBlock)
        {
            _dataList = dataList;
            _textBlock = textBlock;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }

        private void cargarDatos()
        {
            numPagi = 1;
            maxReg = _dataList.Count;
            pageCount = (maxReg / _reg_por_pagina);

            //Ajuste el numero de la pagina si la ultima pagina contiene una parte de la pagina
            if((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 1;
            }
            _textBlock.Text = "Paginas " + "1" + "/ " + pageCount.ToString();
        }

        public int primero()
        {
            numPagi = 1;
            _textBlock.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();

            return numPagi;
        }

        public int anterior()
        {
            if (numPagi > 1)
            {
                numPagi -= 1;
                _textBlock.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
            }

            return numPagi;
        }

        public int siguiente()
        {
            if (numPagi == pageCount)
                numPagi -= 1;
            if (numPagi < pageCount)
            {
                numPagi += 1;
                _textBlock.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();
            }

            return numPagi;
        }

        public int ultimo()
        {
            numPagi = pageCount;
            _textBlock.Text = "Paginas " + numPagi.ToString() + "/ " + pageCount.ToString();

            return numPagi;
        }
    }
}
