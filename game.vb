
Imports System
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Math
module game
dim bar as string = "+----------------------------------------------------------------------------------------------------------------------------------------------------------+" 
dim x as Integer
	Sub Main()
        ''Console.WindowWidth = Console.LargestWindowWidth
        ''Console.WindowHeight = Console.LargestWindowHeight
        ''Console.WindowWidth = 156
        ''Console.WindowHeight = 40
        console.writeline()
        console.writeline(bar)
        for x = 0 to 12
            console.writeline()
        next
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
        for x = 0 to 15
            console.writeline()
        next
        console.writeline(bar)
        console.writeline()
        If Console.ReadLine = "y" Then
            Console.Clear()
            start()
        Else
            End
        End If

    End Sub
    Sub start()
        Dim health As Integer = 100
        Dim situation As Integer 
        dim path as string
        
        
        
        situation = 1
        ''situation = CInt(math.ceiling(Rnd() * 3 )) + 1
        Console.WriteLine(situation)

        If situation = 1 Then

            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.ForegroundColor = ConsoleColor.White
            console.WriteLine(bar)
            for x = 0 To 29
                console.WriteLine()
            next
            console.writeline(bar)
            console.writeline(" Health " & health & "/100 Press 1 or 2 to select your path: ")
            console.writeline(bar)
            console.writeline()
            path = console.ReadLine
            
            if path = "1"
                
            else
            
            end if
        End If
        If situation = 2 Then

            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.ForegroundColor = ConsoleColor.White
            console.WriteLine(bar)
            for x = 0 To 29
                console.WriteLine()
            next
            console.writeline(bar)
            console.writeline(" Health " & health & "/100 Press 1 or 2 to select your path: ")
            console.writeline(bar)
            console.writeline()
            path = console.ReadLine
            
            if path = "1"
                
            else
            
            end if
        End If
        If situation = 3 Then

            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.ForegroundColor = ConsoleColor.White
            console.WriteLine(bar)
            for x = 0 To 29
                console.WriteLine()
            next
            console.writeline(bar)
            console.writeline(" Health " & health & "/100 Press 1 or 2 to select your path: ")
            console.writeline(bar)
            console.writeline()
            path = console.ReadLine
            
            if path = "1"
                
            else
            
            end if
        End If
        If situation = 4 Then

            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                    you come across a forest. The entrance to the forest has 2 paths ")
            Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
            Console.ForegroundColor = ConsoleColor.White
            console.WriteLine(bar)
            for x = 0 To 29
                console.WriteLine()
            next
            console.writeline(bar)
            console.writeline(" Health " & health & "/100 Press 1 or 2 to select your path: ")
            console.writeline(bar)
            console.writeline()
            path = console.ReadLine
            
            if path = "1"
                
            else
            
            end if
        End If


    End Sub
end module 
