using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GestorInventario
{

    [System.Serializable]
    public class Lote
    {
        public TipoObjeto tipo;
        public int numero;
        public int maximo;
        public Sprite icono;
        public Lote ()
        {
            tipo = TipoObjeto.NULL;
            numero = 0;
            maximo = 99;
        }

        public bool PuedeA�adirse()
        {
            if(numero<maximo)
            {
                return true;
            }
            return false;
        }

        public void A�adirseObjeto(Recolectable objeto)
        {
            this.tipo = objeto.tipo;
            this.icono = objeto.icono;
            numero++;
        }
    }

    public List<Lote> lotes = new List<Lote>();

    public GestorInventario(int numLotes)
    {
        for(int i=0; i<numLotes; i++)
        {
            Lote lote = new Lote(); 
            lotes.Add(lote);
        }
    }

    public void A�adirObjeto(Recolectable objeto)
    {
        // Primero se comprueba si ya hay alg�n lote con el tipo del objeto a a�adir
        foreach(Lote a in lotes)
        {
            if(a.tipo == objeto.tipo && a.PuedeA�adirse())
            {
                a.A�adirseObjeto(objeto);
                return;
            }
        }

        // Si no, se a�ade al primer hueco vac�o
        foreach(Lote a in lotes)
        {
            if(a.tipo == TipoObjeto.NULL)
            {
                a.A�adirseObjeto(objeto);
                return;
            }
        }
    }
}
