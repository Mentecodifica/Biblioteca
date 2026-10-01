using Biblioteca;
using System;

class Program
{
    public static string VerificarEmprestimo(object obj)
    {
        return obj switch
        {
            null => "Usuário inválido",

            Aluno { QuantidadeEmprestimosAtivos: < 3 }
                => "Empréstimo autorizado para aluno",

            Aluno { QuantidadeEmprestimosAtivos: >= 3 }
                => "Limite de empréstimos atingido para aluno",

            Professor { QuantidadeEmprestimosAtivos: < 5 }
                => "Empréstimo autorizado para professor",

            Professor { QuantidadeEmprestimosAtivos: >= 5 }
                => "Limite de empréstimos atingido para professor",

            Visitante => "Visitantes não podem realizar empréstimos",

            _ => "Usuário não classificado"
        };
    }

    static void Main(string[] args)
    {
        Aluno aluno = new Aluno
        {
            Nome = "Pedro",
            Matricula = "123456",
            QuantidadeEmprestimosAtivos = 2
        };

        Professor professor = new Professor
        {
            Nome = "Carlos",
            Departamento = "Computação",
            QuantidadeEmprestimosAtivos = 5
        };

        Visitante visitante = new Visitante
        {
            Nome = "João",
            Documento = "123456789",
            QuantidadeEmprestimosAtivos = 0
        };

        UsuarioBiblioteca usuario = new UsuarioBiblioteca
        {
            Nome = "Ana",
            QuantidadeEmprestimosAtivos = 1
        };

        Console.WriteLine(VerificarEmprestimo(aluno));
        Console.WriteLine(VerificarEmprestimo(professor));
        Console.WriteLine(VerificarEmprestimo(visitante));
        Console.WriteLine(VerificarEmprestimo(usuario));
        Console.WriteLine(VerificarEmprestimo(null));
    }

}
