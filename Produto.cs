namespace Carrinho_de_Compra.classes
{
    public class Produto
    {
       public int Codigo { get; set; }
       public string Nome { get; set; }
       public float preco { get; set; }

        public Produto(int codigo, string nome, float preco)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.preco = preco;
            // Produto ItemP = new Produto(codigo, nome, preco);
        }


    }
}