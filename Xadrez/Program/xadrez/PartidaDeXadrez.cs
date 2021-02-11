using System.Collections.Generic;
using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            // Jogada Especial Roque Pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);

                Peca T = tab.retirarPeca(origemTorre);
                T.incrementarQteMovimentos();
                tab.colocarPeca(T, destinoTorre);
            }

            // Jogada Especial Roque Grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);

                Peca T = tab.retirarPeca(origemTorre);
                T.incrementarQteMovimentos();
                tab.colocarPeca(T, destinoTorre);
            }

            // Jogada Especial En Passant
            if(p is Peao)
            {
                if(origem.coluna != destino.coluna && pecaCapturada == null)
                {
                    Posicao posPeao;
                    if(p.cor == Cor.Branca)
                    {
                        posPeao = new Posicao(destino.linha + 1, destino.coluna);
                    }
                    else
                    {
                        posPeao = new Posicao(destino.linha - 1, destino.coluna);
                    }

                    pecaCapturada = tab.retirarPeca(posPeao);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            
            p.decrementarQteMovimentos();
            
            if(pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            tab.colocarPeca(p, origem);

            // Jogada Especial Roque Pequeno
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna + 1);

                Peca T = tab.retirarPeca(destinoTorre);
                T.decrementarQteMovimentos();
                tab.colocarPeca(T, origemTorre);
            }

            // Jogada Especial Roque Grande
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoTorre = new Posicao(origem.linha, origem.coluna - 1);

                Peca T = tab.retirarPeca(destinoTorre);
                T.incrementarQteMovimentos();
                tab.colocarPeca(T, origemTorre);
            }

            // Jogada Especial En Passant
            if(p is Peao)
            {
                if(origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant)
                {
                    Peca peao = tab.retirarPeca(destino);
                    Posicao posPeao;
                    if(p.cor == Cor.Branca)
                    {
                        posPeao = new Posicao(3, destino.coluna);
                    }
                    else
                    {
                        posPeao = new Posicao(4, destino.coluna);
                    }

                    tab.colocarPeca(peao, posPeao);
                }
            }

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca p = tab.peca(destino);

            // Jogada Especial Promoção
            if(p is Peao)
            {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7))
                {
                    p = tab.retirarPeca(destino);
                    pecas.Remove(p);
                    Peca dama = new Dama(tab, p.cor);
                    tab.colocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }

            if(estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if(testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }

            // Jogada Especial En Passant
            if(p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }

        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }

            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if(!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in pecas)
            {
                if (p.cor == cor)
                {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(pecasCapturas(cor));

            return aux;
        } 

        public HashSet<Peca> pecasCapturas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in capturadas)
            {
                if(p.cor == cor)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }

            return Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca p in pecasEmJogo(cor))
            {
                if(p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);

            if(R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }


            foreach (Peca p in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = p.movimentosPosiveis();

                if(matriz[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }

            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            if(!estaEmXeque(cor))
            {
                return false;
            }

            foreach(Peca p in pecasEmJogo(cor))
            {
                bool[,] matriz = p.movimentosPosiveis();

                for(int i=0; i<tab.linhas; i++)
                {
                    for(int j=0; j< tab.colunas; j++)
                    {
                        if(matriz[i, j])
                        {
                            Posicao origem = p.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if(!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('A', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('B', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('C', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('D', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('E', 1, new Rei(tab, Cor.Branca, this));
            colocarNovaPeca('F', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('G', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('H', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('A', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('B', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('C', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('D', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('E', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('F', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('G', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('H', 2, new Peao(tab, Cor.Branca, this));

            colocarNovaPeca('A', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('B', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('C', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('D', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('E', 8, new Rei(tab, Cor.Preta, this));
            colocarNovaPeca('F', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('G', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('H', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('A', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('B', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('C', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('D', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('E', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('F', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('G', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('H', 7, new Peao(tab, Cor.Preta, this));

            
        }
    }
}
