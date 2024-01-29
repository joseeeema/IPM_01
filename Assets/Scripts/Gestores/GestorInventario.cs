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

        public bool PuedeAñadirse()
        {
            if(numero<maximo)
            {
                return true;
            }
            return false;
        }

        public void AñadirseObjeto(Recolectable objeto)
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

    public void AñadirObjeto(Recolectable objeto)
    {
        // Primero se comprueba si ya hay algún lote con el tipo del objeto a añadir
        foreach(Lote a in lotes)
        {
            if(a.tipo == objeto.tipo && a.PuedeAñadirse())
            {
                a.AñadirseObjeto(objeto);
                return;
            }
        }

        // Si no, se añade al primer hueco vacío
        foreach(Lote a in lotes)
        {
            if(a.tipo == TipoObjeto.NULL)
            {
                a.AñadirseObjeto(objeto);
                return;
            }
        }
    }
}
