Imports System
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates

Module Program
    Sub Main()
        Console.WriteLine("Welcome to my text based rpg! ")
        Console.WriteLine()
        Console.WriteLine("would you like to start a game? y/n ")
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
        Console.WindowHeight = Console.LargestWindowHeight
        Console.WindowWidth = Console.LargestWindowWidth
        Console.SetWindowPosition(0, 0)
        Console.windows





        situation = 1
        Randomize()
        ''situation = CInt(Rnd() * 3 + 1)
        Console.WriteLine(situation)

        If situation = 1 Then
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------------------------------------------+")
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------------------------------------------+")
            Console.WriteLine()
        End If


    End Sub
End Module
