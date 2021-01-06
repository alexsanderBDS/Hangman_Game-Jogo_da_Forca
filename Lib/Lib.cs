using System;
using static System.Console;
using System.Collections.Generic;

namespace Lib
{

    public class Body
    {
        public string head = " ";
        public string rightArm = "";
        public string leftArm = "";
        public string trunk = "   ";
        public string rightLeg = "  ";
        public string leftLeg = "";        
    }

    public class Score
    {
        public int wins;
        public int loses;
    }

    public class Game
    {

        public Game () {

            Score score = new Score();
            bool running = true;
            while (running)
            {
                var result = this.SortNumbers();
                Validator(result, score);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Deseja Continuar o jogo: [n] -> Para cancelar, [*] -> Outra tecla para Continuar ?");
                var res = ReadLine();

                if (res == "n")
                {
                    running = false;
                    WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Vitórias: {score.wins}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Derrotas: {score.loses}");
                }
            }
        }

        static void ShowInfo(string[] result, List<string> corrects, int tries, Body body)
        {

            Console.Clear();

            switch (tries)
            {
                case 1:
                    body.head = "O";
                break;
                case 2:
                    body.rightArm = "-";
                    body.leftArm = "-";
                    body.trunk = "|";
                break;
                case 3:
                    body.rightLeg = "/";
                    body.leftLeg = @"\";
                break;
                default:
                break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            WriteLine();
            WriteLine("  ____________");
            WriteLine(" |            |");
            WriteLine(" |            |");
            WriteLine($" {body.head}            |");
            WriteLine($"{body.rightArm}{body.trunk}{body.leftArm}           |");
            WriteLine($"{body.rightLeg} {body.leftLeg}           |");
            WriteLine("              |");
            WriteLine("           ___|___");

            WriteLine();
            WriteLine($"É um(a) {result[1]} com {result[0].Length} letras.");

            Console.ForegroundColor = ConsoleColor.White;

            string hide = "";

            for(int i = 0; i < result[0].Length; i++)
            {
                char charResult = result[0].ToLower()[i];

                if (corrects.Contains(charResult + ""))
                {
                    hide += charResult;
                    hide += " ";
                }
                else
                {
                    hide += "_";
                    hide += " ";

                }

            }

            if (!hide.Contains("_"))
            {
                result[0] = hide;
            }

            int length = SubValidation(result[0].ToLower());

            WriteLine(hide);
            WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (tries == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                WriteLine("Já foram 3 Tentativas Erradas, diga agora o nome!");
                WriteLine();
            }else
            {
                var times = tries == 0 ? null : $"{tries}º Tentativa Errada!";
                WriteLine(times);
                WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Informe uma letra ou qual a palavra (sem caractere especial) ?");
            hide = "";
        }

        static void Validator(string[] result, Score score)
        {   

            Body body = new Body();
            bool run = true;
            int tries = 0;
            var corrects = new List<string>();

            while (run)
            {

                ShowInfo(result, corrects, tries, body);

                Console.ForegroundColor = ConsoleColor.White;
                string response = ReadLine().ToLower().Trim();
                int length = SubValidation(result[0].ToLower());

                if (corrects.Count == length)
                {
                    response = result[0].ToLower();
                }

                if (response.Length == 1 && tries < 3)
                {

                    if (result[0].ToLower().Trim().Contains(response))
                    {
                        
                        if (!corrects.Contains(response))
                        {
                            corrects.Add(response);
                        }

                    }
                    else
                    {
                        tries++;
                    }
                }

                else if (result[0].ToLower() == response)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("Resposta Correta!");
                    run = false;

                    score.wins++;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Perdeu!");
                    run = false;
                    score.loses++;

                }
            }   

        }

        static int SubValidation(string result) {
            
            List<char> list = new List<char>();

            foreach (var i in result)
            {
                if (!list.Contains(i))
                {
                    list.Add(i);
                }
            }

            return list.Count - 1;
        }

        public string[] SortNumbers() {

            Random numberOption = new Random();
            Category category = new Category();

            int animalLength = numberOption.Next(0, category.animals.Length - 1);
            int colorLength = numberOption.Next(0, category.colors.Length - 1);
            int countryLength = numberOption.Next(0, category.countries.Length - 1);
            int exerciseLength = numberOption.Next(0, category.exercises.Length - 1);
            int foodLength = numberOption.Next(0, category.foods.Length - 1);

            Category animal = new Category(animalLength, "animal");
            Category color = new Category(colorLength, "cor");
            Category country = new Category(countryLength, "pais");
            Category exercise = new Category(exerciseLength, "exercicio");
            Category food = new Category(foodLength, "comida");

            string[] options = 
            {
                animal.result,
                color.result,
                country.result,
                exercise.result,
                food.result
            };

            string[] type = 
            {
                animal.type,
                color.type,
                country.type,
                exercise.type,
                food.type
            };

            Random numberCategory = new Random();
            int number = numberCategory.Next(0, options.Length - 1);

            string[] join = {options[number], type[number]};

            return join;

    }

    public class Category
    {
        public string[] animals = 
        {
            "Leopardo",
            "Zebra",
            "Cobra",
            "Leao",
            "Capivara",
            "Tigre",
            "Ornintorrinco",
            "Camaleao",
            "Urubu",
            "Sapo",
            "Coruja",
            "Largato",
            "Elefante",
            "Centopeia",
            "Bufalo",
            "Hinoceronte",
            "Macaco",
            "Gorila",
            "Gato",
            "Cachorro",
            "Camundongo",
            "Carangueijo",
            "Tartaruga",
            "Tamandua",
            "Tucano",
            "Jacare",
            "Joaninha"
        };

        public string[] colors =
        {
            "Cinza",
            "Azul",
            "Amarelo",
            "Verde",
            "Marrom",
            "Vermelho",
            "Laranja",
            "Roxo",
            "Rosa",
            "Ciano",
            "Dourado",
            "Indigo",
            "Magenta",
            "Salmao"
        };

        public string[] foods =
        {
            "Macarrao",
            "Carne",
            "Arroz",
            "Feijao",
            "Macarronada",
            "Sushi",
            "Pure",
            "Salcicha",
            "Hamburguer",
            "Peixe",
            "Frango",
            "Salada",
            "Chocolate",
            "Sorvete"
        };

        public string[] exercises =
        {
            "Correr",
            "Alongamento",
            "Prancha",
            "Musculacao",
            "Hit",
            "Aquecimento"
        };

        public string[] countries =
        {
            "Brasil",
            "Canada",
            "China",
            "Franca",
            "Italia",
            "Angola",
            "Russia",
            "Argentina",
            "Croacia",
            "Inglaterra",
            "Finlandia",
            "Holanda",
            "Gana",
            "Chile",
            "Argelia",
            "Uzbequistao",
            "Grecia",
            "Irlanda",
            "Zimbabue",
            "Nigeria",
            "Portugal",
            "Espanha",
            "Australia",
            "Bolivia",
            "Cuba",
            "Equador",
            "Eslovenia",
            "Indonesia",
            "Israel",
            "Macedonia",
            "Mongolia",
            "Polonia",
            "Senegal",
            "Turquia",
            "Uruguai",
            "Ucrania",
            "Venezuela",
            "Vietnam",
            "Servia",
            "Paraguai",
            "Nicaragua"
        };

        public string result = "";
        public string type = "";
        // private string category = "Animais";
        public Category(int number, string category) {
            
            switch (category)
            {
                case "animal":
                    result = animals[number];
                    type = category;
                break;
                case "cor":
                    result = colors[number];
                    type = category;
                break;
                case "pais":
                    result = countries[number];
                    type = category;
                break;
                case "exercicio":
                    result = exercises[number];
                    type = category;
                break;
                case "comida":
                    result = foods[number];
                    type = category;
                break;
                default:
                break;
            }
            
        
        }
        public Category() {}

    }

}

}
