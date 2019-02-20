using System;
using System.Collections.Generic;

namespace RSAEncryptionTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            //Only works up to the m char, for now
            int encryptKey1 = 5; // e
            int encryptKey2 = 14; // n

            int decryptKey1 = 11; // d
            int decryptKey2 = encryptKey2; // n

            var encoder = new Encoder();
            var decoder = new Decoder();
            var encryptor = new Encryptor();
            var decryptor = new Decryptor();

            char[] alphabet = { 'a', 'b', 'c', 'd',
                                  'e', 'f', 'g', 'h',
                                  'i', 'j', 'k', 'l',
                                  'm', 'n', 'o', 'p',
                                  'q', 'r', 's', 't',
                                  'u', 'v', 'w', 'x',
                                            'y', 'z' };

            Console.WriteLine("Input text to encrypt and decrypt\n");

            var input = Console.ReadLine();
            Console.WriteLine("Returning input: " + input);


            var encodedChars = encoder.encodeAllChars(input, alphabet);
            var encryptInts = encryptor.encrypt(encodedChars, encryptKey1, encryptKey2);
            var decryptInts = decryptor.decrypt(encryptInts, decryptKey1, decryptKey2);
            var decoderString = decoder.decodeAllChars(decryptInts, alphabet);


            for (var i = 0; i < encodedChars.Length; i++)
            {
                Console.WriteLine("encodedChars index " + i + ": " + encodedChars[i]);
            }

            Console.WriteLine("\n");

            for (var i = 0; i < encryptInts.Length; i++)
            {
                Console.WriteLine("encryptInts index " + i + ": " + encryptInts[i]);
            }

            Console.WriteLine("\n");

            for (var i = 0; i < decryptInts.Length; i++)
            {
                Console.WriteLine("decryptInts index " + i + ": " + decryptInts[i]);
            }

            Console.WriteLine("\n");

            for (var i = 0; i < decoderString.Length; i++)
            {
                Console.WriteLine("decoderString index " + i + ": " + decoderString[i]);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Press eny key...");
            Console.ReadKey();
        }


        class Encoder
        {
            public int[] encodeAllChars(string input, char[] alphabet)
            {
                List<int> convInts = new List<int>();
                var splitInput = input.ToCharArray();

                for (var i = 0; i < splitInput.Length; i++)
                {
                    for (var j = 0; j < alphabet.Length; j++)
                    {
                        if (splitInput[i] == alphabet[j])
                        {
                            var tempDecode = j + 1;
                            convInts.Add(tempDecode);
                        }
                    }
                }
                return convInts.ToArray();
            }
        }

        class Encryptor
        {
            public int[] encrypt(int[] encoded, int n, int e)
            {
                List<int> dectryptedInts = new List<int>();

                for (var i = 0; i < encoded.Length; i++)
                {
                    var tempCalc = Math.Pow(encoded[i], n) % e;
                    dectryptedInts.Add(Convert.ToInt32(tempCalc));
                }
                int[] result = dectryptedInts.ToArray();
                return result;
            }
        }

        class Decryptor
        {
            public int[] decrypt(int[] encrypted, int d, int e)
            {
                List<int> decryptedInts = new List<int>();

                for (var i = 0; i < encrypted.Length; i++)
                {
                    var tempCalc = Math.Pow(encrypted[i], d) % e;
                    var tempCalc2 = tempCalc / e;
                    var tempCalc3 = Math.Floor(tempCalc2) - tempCalc2;
                    var tempCalc4 = tempCalc3 * e;
                    var tempCalc5 = Math.Abs(Math.Ceiling(tempCalc4));
                    Console.WriteLine(Convert.ToString(tempCalc5));
                    decryptedInts.Add(Convert.ToInt32(tempCalc5));
                }
                return decryptedInts.ToArray();
            }
        }

        class Decoder
        {
            public string[] decodeAllChars(int[] decryptedInts, char[] alphabet)
            {
                List<string> decodedStrings = new List<string>();

                for (var i = 0; i < decryptedInts.Length; i++)
                {
                    decodedStrings.Add(Convert.ToString(alphabet[decryptedInts[i] - 1]));
                }

                return decodedStrings.ToArray();
            }
        }
    }
}
