Imports System
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates

Module game

    Sub Main()
        ''Console.WindowWidth = Console.LargestWindowWidth
        ''Console.WindowHeight = Console.LargestWindowHeight
        Console.WindowWidth = 156
        Console.WindowHeight = 40

        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("   _,-='""-.__               /\_/\")
        Console.Write("   `-.}       `=._,.-==-._.,  @ @._,")
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("                             Welcome to my text based rpg! ")
        Console.ForegroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Red

        Console.WriteLine("      `-.__   _,-.   )       _,.-'")
        Console.WriteLine("           `""     G..m-""^m`m'")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine("                                                               would you like to start a game? y/n ")
        If Console.ReadLine = "y" Then
            Console.Clear()
            start()
        Else
            End
        End If

    End Sub
    Sub start()
        Dim health As Integer
        Dim situation As Integer





        situation = 1
        Randomize()
        ''situation = CInt(Rnd() * 3 + 1)
        Console.WriteLine(situation)

        If situation = 1 Then

            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------------------------------------------+")
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------------------------------------------+")
            Console.WriteLine()
        End If


    End Sub
End Module
