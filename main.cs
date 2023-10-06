using System;

class User {
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Genero { get; set; }

    public User() { }

    public User(string nome, int idade, string genero) {
        Nome = nome;
        Idade = idade;
        Genero = genero;
    }
}

class Conta : User {
    private double saldo = 0;

    public double Saldo {
        get { return saldo; }
        private set { saldo = value; }
    }

    public void Depositar(double deposito) {
        if (deposito > 0) {
            saldo += deposito;
            Console.WriteLine($"Depósito de R${deposito:N2} realizado com sucesso!");
        }
    }

    public bool Sacar(double saque) {
        if (saque <= saldo) {
            saldo -= saque;
            Console.WriteLine($"Saque de R${saque:N2} realizado com sucesso!");
            return true;
        } else {
            Console.WriteLine("Não é possível realizar o saque, saldo insuficiente!");
            return false;
        }
    }
}

class Program {
    public static void Main(string[] args) {
        Conta contaBancaria = new Conta {
            Nome = "Eduardo",
            Idade = 28,
            Genero = "Masculino"
        };

        contaBancaria.Depositar(10);
        contaBancaria.Sacar(20);
        contaBancaria.Depositar(50);
        contaBancaria.Sacar(25);

        Console.WriteLine($"O usuário {contaBancaria.Nome} tem {contaBancaria.Idade} anos do sexo {contaBancaria.Genero}");

        Console.Write("Deseja ver o saldo? (Sim/Não): ");
        string resposta = Console.ReadLine();

        if (resposta.Equals("sim", StringComparison.OrdinalIgnoreCase)) {
            Console.WriteLine($"O saldo atual é de R$ {contaBancaria.Saldo:N2}");
        } else {
            Console.WriteLine("Fim do programa!");
        }
    }
}