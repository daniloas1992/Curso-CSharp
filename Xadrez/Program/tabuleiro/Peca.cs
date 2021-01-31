﻿namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) 
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPosiveis();
            
            for(int i=0; i < tab.linhas; i++)
            {
                for(int j=0; j < tab.colunas; j++)
                {
                    if(matriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPosiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPosiveis();
    }
}
