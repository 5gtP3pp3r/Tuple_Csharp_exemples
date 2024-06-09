namespace Tuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Voici des exemples simple d'utilisations de tuple. Un bon avantage est que
            // l'utilisation d'un tuple permet de raccourcir un peut le nombre de ligne de codes
            // et de regrouper des valeurs pertinentes ensemble.

            // Disons que nous voulons établir les valeurs de 2 variables avec le même type de fonction.
            // De manière standard, on utiliserai 2 fonctions différente pour des valeurs différente.



            // Exemple 1
            int value1 = GetValue1();
            int value2 = GetValue2();

            Console.WriteLine("Les valeurs de value1 et value2 sont: " + value1 + " et " + value2);


            // La même actions pour des valeurs différente mais avec un lien ou une raison semblable
            // de déterminer 2 valeurs avec le tuple utilisant une seule fonctions. 
            
            // À noter la fonction doit être logique et être utilisé pour des valeurs qui ont soit un 
            // rapport ensemble ou venant, par exemple d'un même objet. On utilisera pas le tuple simplement 
            // pour raccourcir le code. Les valeurs ont un liens entre elles. 



            // Exemple 2
            (int tuple1, int tuple2) = GetValues();
            // Déclaration (item 1, item 2)
            // **IMPORTANT** Les valeurs doivent TOUJOURS suivre le même ordre,
            // dans la déclaration, la signature de la fonction et les retours

            Console.WriteLine("Les mêmes valeurs avec tuple sont: " + tuple1 + " et " + tuple2);

            

            // Exemple 3
            int number = 9;
            int divider = 3;
            (int division, int modulo) = ModuloDiv(number, divider);
            // Nous allons entrer un nombre et un diviseur, la fonction divisera le nombre par le diviseur
            // et effectuera aussi un modulo avec le même diviseur.

            Console.WriteLine($"\nLe nombre {number} / {divider} = {division}.");
            Console.WriteLine($"Le nombre {number} % {divider} = {modulo}.");



            //Exemple 4
            // Le tuple peut être utile dans le cas où on voudrait échanger des valeurs.
            // Ici on 2 "string" avec des valeurs différentes.
            string nom1 = "Jean";
            string nom2 = "Pierre";
            Console.WriteLine($"le nom1 est {nom1} et le nom2 est {nom2}");

            (nom1, nom2) = (nom2, nom1);
            Console.WriteLine($"le nom1 est {nom1} et le nom2 est {nom2}");
            // Le tuple permet donc de facilement échanger des valeurs sans avoir à instancier une variable temporaire.
            // Donc utile dans une fonction comme un bubble sort



            // Exemple 5
            // Vous vous rappelez du TP2 de POO? On avait deux valeurs pour chaque armes. Il y avait donc une 
            // bonne raison d'utiliser un tuple puisque chaque armes avait des points pour l'attaque et la défense.
            // dans cette boucle j'affiche avec l'aide du tuple les 2 valeurs de chaque arme.
            Console.WriteLine();
            foreach (Weapons weapon in Enum.GetValues(typeof(Weapons)))
            {
                (int attackPts, int defensePts) = SetPtsByWeapons(weapon);
                Console.WriteLine($"{weapon}, points d'attaque: {attackPts}, points de defense: {defensePts}\n");
            }



            // Exemple 6
            // On pourrait aussi définir dans une variable les 2 valeurs
            // de l'item soit le nom et sa valeur dans l'enum! 
            var bow = (Weapons.Bow, (int)Weapons.Bow);
            Console.WriteLine("\n" + bow);
            // À noter que le type "var" a été utilisé car "bow" n'a pas réellement
            // de type propre. En fait il en utilise 2 , un "Weapons" et un "int".

            // Et même additionner ou multiplier la valeur numérique de l'arme.
            int sum = bow.Item2 + bow.Item2;
            Console.WriteLine("\n\"somme\": " + sum);

            // Ou afficher seulement la première valeur.
            Console.WriteLine("\n\"nom\": " + bow.Item1.ToString());
            // Remarquez que les ".Item1" et ".Item2" représentent les positions des valeurs dans le tuple.



            // Exemple 7
            // Un tuple n'est pas restraint à seulement 2 valeurs...
            var fourValuesVar = (1, 2, 3, 4);

            // Et on peut vraiment faire n'importe quoi!
            fourValuesVar.Item1 = fourValuesVar.Item2;
            fourValuesVar.Item3 = fourValuesVar.Item4;

            Console.WriteLine("\n" + fourValuesVar);

            int SumOfAllValues = fourValuesVar.Item1 + fourValuesVar.Item2 + fourValuesVar.Item3 + fourValuesVar.Item4;
            Console.WriteLine("\nSomme de toutes les valeurs: " + SumOfAllValues);



            // Exemple 8 
            // On peut utiliser les tuples avec n'importe quel type. Disons
            // que l'on a plusieurs objets à initialiser pour un programme,
            // on pourrait tous les initialiser dans une seule fonction.

            (FakeClass fakeClass, AnOtherClass anOtherClass, List<String> list, bool[] trueOrFalse) = Initialisation();

            Console.WriteLine("\n" + fakeClass.Name + "\n" + anOtherClass.Number);
            PrintCollection(list);
            PrintCollection(trueOrFalse);
            Console.WriteLine();



            // Exemple 9
            // Les valeurs dans un tuple peuvent être simplifiés. Parfois une fonction pourrait avoir
            // comme paramètre des objets qui ont plusieurs valeurs,mais la fonction n'utilisera
            // qu'une seule des 2 valeurs. L'exemple de simplification se retrouve dans la fonction
            // "ComputDamagePtsWeaponAndClass()" plus bas dans "Exemple 9:" .
            var simpleBow = SetPtsByWeapons(Weapons.Bow);
            var shortSword = SetPtsByWeapons(Weapons.Sword);
            // Chaque armes est instanciées avec ses 2 valeurs.
            Console.WriteLine($"\nDommages arc: {simpleBow.Item1}");
            Console.WriteLine($"Dommages épé: {shortSword.Item1}");

            var ranger = SetPtsByClass(Class.Ranger);
            var warrior = SetPtsByClass(Class.Warrior);
            // Chaque classe est instanciées avec ses 2 valeurs.
            Console.WriteLine($"\nDommages archer: {ranger.Item1}");
            Console.WriteLine($"Dommages guerrier: {warrior.Item1}");


            int rangerWithBow = ComputDamagePtsWeaponAndClass(Weapons.Bow, Class.Ranger);
            int warriorWithSword = ComputDamagePtsWeaponAndClass(Weapons.Sword, Class.Warrior);
            // les variables "rangerWithBow" et "warriorWithSword" ont été instanciées avec les valeurs 
            // des dommages additionnés de leurs armes et classes.                       
            Console.WriteLine($"\nDommages archer avec arc: {rangerWithBow}");                        
            Console.WriteLine($"Dommages guerrier avec épé: {warriorWithSword}");
        }


        //****** Fonctions ******
        // À noter, les fonctions sont simplifiées au maximum pour fin d'exemple.

            // Exemple 1: Deux fonctions                      
        public static int GetValue1()
        {
            return 1;
        }
        public static int GetValue2()
        {
            return 2;
        }

        // Exemple 2: Une fonctions avec tuple
        public static (int, int) GetValues()
        // signature (item 1, item 2)
        {
            return (1, 2);
         // retour (item 1, item 2)
        }

        // Exemple 3: Fonction qui prend 2 paramètres et retourne les résultats sous forme de tuple
        public static (int,int) ModuloDiv(int number, int divider )
        {
            return (number / divider, number % divider);
        }

        // Exemple 5: Fonction qui retourne des points d'attaques ET de défenses des armes
        //            retour sous forme de tuple.
        public static (int, int) SetPtsByWeapons(Weapons weapon)
        {
            return weapon switch
            {
                Weapons.Fists => (1, 0), 
                Weapons.Bow => (3, 1),
                Weapons.Sword => (5, 2),
                _ => (0, 0),
            };
        }
        //            Fonction qui retourne des points d'attaques ET de défenses des classes
        //            retour sous forme de tuple.
        public static (int, int) SetPtsByClass(Class @class)
        {
            return @class switch
            {
                Class.monk => (1, 0),
                Class.Ranger => (2, 1),
                Class.Warrior => (3, 2),
                _ => (0, 0),
            };
        }

        // Exemple 8: Instanciation de plusieurs types dans la même fonction et retour sous forme de tuple (4 valeurs)
        public static (FakeClass, AnOtherClass, List<String>, bool[]) Initialisation()
        {
            FakeClass fakeClass = new("mille-vingt-quatre");
            AnOtherClass anOtherClass = new(1024);
            List<String> list = ["string 1", "string 2", "string 3"];
            bool[] trueOrFalse = [true, false];

            return (fakeClass, anOtherClass, list, trueOrFalse);
        }

        // Exemple 9: Simplification des valeurs dans un tuple
        public static int ComputDamagePtsWeaponAndClass(Weapons weapon, Class @class)
        {
            (int weaponDamage, _) = SetPtsByWeapons(weapon);
            //              *  ^  simplification, valeur inutile pour le calcule.*
            (int classDamage, _) = SetPtsByClass(@class);
            //             *  ^  *

            // Lorsqu'un objet qui utilise un tuple est utilisé. il est possible d'ignorer une des valeurs.
            // Ici on n'était intéressé que par les points de dommages, donc les points de défenses étaient
            // inutiles. Les points de défenses existe toujours, mais puisqu'on en avait pas besoin nous
            // avons simplifié l'équation avec " _ ". De cette manière l'utilisation des valeurs utiles reste
            // simple au visuel pour la lecture du code. La fonction ne sera pas remplis de valeur inutile.
            return (weaponDamage + classDamage);
            // Bien sure la fonction retourne donc un seul "int", mais elle aurait pu aussi retourner un
            // tuple avec toutes les valeurs additionnées, dommages et défense, mais le but de l'exemple
            // était de montrer la syntaxe de simplification (_) de valeur dans un tuple.
        }

        // Fonction qui permet d'afficher autant une liste qu'un tableau de n'importe quel type...
        // pratique! À garder en note!
        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            bool isFirstItem = true;
            foreach (var item in collection) 
            {
                if (isFirstItem)
                {
                    Console.Write("\n[ " + item);
                    isFirstItem = false;
                }
                else
                {
                    Console.Write(", " + item);
                }               
            }
            Console.Write(" ]");
        }
    }
}
