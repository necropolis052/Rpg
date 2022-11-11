Imports System
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Math

'#############################TO DO LIST#############################
'
'implament the commands function and get it working so you can move around with if statements checking if a move is possible and then changing co-ordinates if so
'
'

Structure location
    Dim Name As String
    Dim Description As String
    Dim North, East, South, West As Boolean
    Dim items As String
    Dim Npcs As String
End Structure

Structure self
    Dim Pname As String
    Dim hp As Integer
    Dim mp As Integer
    Dim status_effects() As String
End Structure

Module game



    Function help_menu() As String
        Dim x As String
        Console.Clear()
        Console.WriteLine(bar)
        Console.WriteLine("                                                  Type a command such as 'move' then 'left' to nagivate the map .")
        Console.WriteLine("                                               Inputs such as 'look' or 'examine' will let you interact with rooms.")
        Console.WriteLine("                                                           Please ensure to type in lowercase for ease.")
        Console.WriteLine(bar)
        Console.WriteLine("                                                               Please select an option to continue.     ")
        Console.WriteLine(bar)
        Console.WriteLine("                                                                            .: Play :.                  ")
        Console.WriteLine("                                                                            .: Help :.                  ")
        Console.WriteLine("                                                                            .: Quit :.                  ")
        x = Console.ReadLine()
        title_screen_options(x)
    End Function

    Function title_screen_options(x As String) As String
        Dim a As String = "play"
        Dim b As String = "help"
        Dim c As String = "quit"
        Dim opt As String
        opt = x
        If opt.ToLower = ("play") Then
            start()
        ElseIf opt.ToLower = ("quit") Then
            End
        ElseIf opt.ToLower = ("help") Then
            help_menu()
        End If
    End Function

    Function title_screen() As String
        Dim y As String
        Console.WriteLine()
        Console.WriteLine(bar)
        For x = 0 To 12
            Console.WriteLine()
        Next
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("   _,-='""-.__               /\_/\")
        Console.Write("   `-.}       `=._,.-==-._.,  @ @._,")
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("                              Welcome to my text based rpg! ")
        Console.ForegroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Red

        Console.WriteLine("      `-.__   _,-.   )       _,.-'")
        Console.WriteLine("           `""     G..m-""^m`m'")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine("                                                                           .: Play :.                  ")
        Console.WriteLine("                                                                           .: Help  :.                  ")
        Console.WriteLine("                                                                           .: Quit :.                  ")
        Console.WriteLine(bar)
        Console.WriteLine()
        Console.Write("> ")
        y = Console.ReadLine()
        title_screen_options(y)
    End Function


    Function inp() As String
        Dim input As String
        Console.Clear()
        Console.WriteLine(print_location(playerx, playery))
        Console.WriteLine()
        Console.Write("> ")
        input = Console.ReadLine()
        Console.WriteLine(commands(input))
        Console.WriteLine()




    End Function

    Function commands(command As String) As String
        command = command.ToLower
        If command = "north" Then
            If Map(playerx, playery).North = True Then
                playery = playery - 1
                'loops back to input function to catch another command
                inp()
            Else
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.Write("> ")
                command = Console.ReadLine()
                Console.WriteLine(inp(command))

            End If
        ElseIf command = "east" Then
            If Map(playerx, playery).East = True Then
                playerx = playerx + 1
                inp()
            Else
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.Write("> ")
                command = Console.ReadLine()
                Console.WriteLine(inp(command))

            End If

        ElseIf command = "south" Then
            If Map(playerx, playery).South = True Then
                playery = playery + 1
                inp()
            Else
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.Write("> ")
                command = Console.ReadLine()
                Console.WriteLine(inp(command))

            End If
        ElseIf command = "west" Then
            If Map(playerx, playery).West = True Then
                playerx = playerx - 1
                inp()
            Else
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.Write("> ")
                command = Console.ReadLine()
                Console.WriteLine(inp(command))

            End If
        ElseIf command = "inventory" Then

        ElseIf command = "block" Then

        ElseIf command = "attack" Then

        End If


    End Function

    Function print_location(a, b) As String

        For x = 0 To (Map(a, b).Name.Length + 3)
            Console.Write("#")
        Next
        Console.WriteLine()
        Console.WriteLine("# " & Map(a, b).Name & " #")
        For x = 0 To (Map(a, b).Name.Length + 3)
            Console.Write("#")
        Next
        Console.WriteLine()
        Console.WriteLine("Description: " & Map(a, b).Description)
        Console.WriteLine("The items in " & Map(a, b).Name & " are as follows: " & Map(a, b).items)

    End Function

    Dim playerx, playery As Integer
    Dim Map(10, 10) As location
    Dim bar As String = "+----------------------------------------------------------------------------------------------------------------------------------------------------------+"
    Dim x As Integer
    Dim name As self
    Dim res As String

    Sub Main()

        title_screen()

    End Sub
    Sub start()
        Console.Clear()
        Console.WriteLine("what's your name brave adventurer? ")
        name.Pname = Console.ReadLine()
        Console.Clear()
        playerx = 0
        playery = 0

        Map(0, 0).Name = "james's house"
        Map(0, 0).Description = "house"
        Map(0, 0).North = False
        Map(0, 0).East = True
        Map(0, 0).South = True
        Map(0, 0).West = False
        Map(0, 0).items = "james"

        Map(0, 1).Name = ""
        Map(0, 1).Description = ""
        Map(0, 1).North = True
        Map(0, 1).East = True
        Map(0, 1).South = True
        Map(0, 1).West = False
        Map(0, 1).items = ""

        Map(0, 2).Name = ""
        Map(0, 2).Description = ""
        Map(0, 2).North = True
        Map(0, 2).East = True
        Map(0, 2).South = True
        Map(0, 2).West = False
        Map(0, 2).items = ""

        Map(0, 3).Name = ""
        Map(0, 3).Description = ""
        Map(0, 3).North = True
        Map(0, 3).East = True
        Map(0, 3).South = True
        Map(0, 3).West = False
        Map(0, 3).items = ""

        Map(0, 4).Name = ""
        Map(0, 4).Description = ""
        Map(0, 4).North = True
        Map(0, 4).East = True
        Map(0, 4).South = True
        Map(0, 4).West = False
        Map(0, 4).items = ""

        Map(0, 5).Name = ""
        Map(0, 5).Description = ""
        Map(0, 5).North = True
        Map(0, 5).East = True
        Map(0, 5).South = True
        Map(0, 5).West = False
        Map(0, 5).items = ""

        Map(0, 6).Name = ""
        Map(0, 6).Description = ""
        Map(0, 6).North = True
        Map(0, 6).East = True
        Map(0, 6).South = True
        Map(0, 6).West = False
        Map(0, 6).items = ""

        Map(0, 7).Name = ""
        Map(0, 7).Description = ""
        Map(0, 7).North = True
        Map(0, 7).East = True
        Map(0, 7).South = True
        Map(0, 7).West = False
        Map(0, 7).items = ""

        Map(0, 8).Name = ""
        Map(0, 8).Description = ""
        Map(0, 8).North = True
        Map(0, 8).East = True
        Map(0, 8).South = True
        Map(0, 8).West = False
        Map(0, 8).items = ""

        Map(0, 9).Name = ""
        Map(0, 9).Description = ""
        Map(0, 9).North = True
        Map(0, 9).East = True
        Map(0, 9).South = True
        Map(0, 9).West = False
        Map(0, 9).items = ""

        Map(0, 10).Name = ""
        Map(0, 10).Description = ""
        Map(0, 10).North = True
        Map(0, 10).East = True
        Map(0, 10).South = False
        Map(0, 10).West = False
        Map(0, 10).items = ""

        'start of 1

        Map(1, 0).Name = ""
        Map(1, 0).Description = ""
        Map(1, 0).North = False
        Map(1, 0).East = True
        Map(1, 0).South = True
        Map(1, 0).West = True
        Map(1, 0).items = ""

        Map(1, 1).Name = ""
        Map(1, 1).Description = ""
        Map(1, 1).North = True
        Map(1, 1).East = True
        Map(1, 1).South = True
        Map(1, 1).West = True
        Map(1, 1).items = ""

        Map(1, 2).Name = ""
        Map(1, 2).Description = ""
        Map(1, 2).North = True
        Map(1, 2).East = True
        Map(1, 2).South = True
        Map(1, 2).West = True
        Map(1, 2).items = ""

        Map(1, 3).Name = ""
        Map(1, 3).Description = ""
        Map(1, 3).North = True
        Map(1, 3).East = True
        Map(1, 3).South = True
        Map(1, 3).West = True
        Map(1, 3).items = ""

        Map(1, 4).Name = ""
        Map(1, 4).Description = ""
        Map(1, 4).North = True
        Map(1, 4).East = True
        Map(1, 4).South = True
        Map(1, 4).West = True
        Map(1, 4).items = ""

        Map(1, 5).Name = ""
        Map(1, 5).Description = ""
        Map(1, 5).North = True
        Map(1, 5).East = True
        Map(1, 5).South = True
        Map(1, 5).West = True
        Map(1, 5).items = ""

        Map(1, 6).Name = ""
        Map(1, 6).Description = ""
        Map(1, 6).North = True
        Map(1, 6).East = True
        Map(1, 6).South = True
        Map(1, 6).West = True
        Map(1, 6).items = ""

        Map(1, 7).Name = ""
        Map(1, 7).Description = ""
        Map(1, 7).North = True
        Map(1, 7).East = True
        Map(1, 7).South = True
        Map(1, 7).West = True
        Map(1, 7).items = ""

        Map(1, 8).Name = ""
        Map(1, 8).Description = ""
        Map(1, 8).North = True
        Map(1, 8).East = True
        Map(1, 8).South = True
        Map(1, 8).West = True
        Map(1, 8).items = ""

        Map(1, 9).Name = ""
        Map(1, 9).Description = ""
        Map(1, 9).North = True
        Map(1, 9).East = True
        Map(1, 9).South = True
        Map(1, 9).West = True
        Map(1, 9).items = ""

        Map(1, 10).Name = ""
        Map(1, 10).Description = ""
        Map(1, 10).North = True
        Map(1, 10).East = True
        Map(1, 10).South = False
        Map(1, 10).West = True
        Map(1, 10).items = ""

        'start of 2 

        Map(2, 0).Name = ""
        Map(2, 0).Description = ""
        Map(2, 0).North = False
        Map(2, 0).East = True
        Map(2, 0).South = True
        Map(2, 0).West = True
        Map(2, 0).items = ""

        Map(2, 1).Name = ""
        Map(2, 1).Description = ""
        Map(2, 1).North = False
        Map(2, 1).East = True
        Map(2, 1).South = True
        Map(2, 1).West = True
        Map(2, 1).items = ""

        Map(2, 2).Name = ""
        Map(2, 2).Description = ""
        Map(2, 2).North = True
        Map(2, 2).East = True
        Map(2, 2).South = True
        Map(2, 2).West = True
        Map(2, 2).items = ""

        Map(2, 3).Name = ""
        Map(2, 3).Description = ""
        Map(2, 3).North = True
        Map(2, 3).East = True
        Map(2, 3).South = True
        Map(2, 3).West = True
        Map(2, 3).items = ""

        Map(2, 4).Name = ""
        Map(2, 4).Description = ""
        Map(2, 4).North = True
        Map(2, 4).East = True
        Map(2, 4).South = True
        Map(2, 4).West = True
        Map(2, 4).items = ""

        Map(2, 5).Name = ""
        Map(2, 5).Description = ""
        Map(2, 5).North = True
        Map(2, 5).East = True
        Map(2, 5).South = True
        Map(2, 5).West = True
        Map(2, 5).items = ""

        Map(2, 6).Name = ""
        Map(2, 6).Description = ""
        Map(2, 6).North = True
        Map(2, 6).East = True
        Map(2, 6).South = True
        Map(2, 6).West = True
        Map(2, 6).items = ""

        Map(2, 7).Name = ""
        Map(2, 7).Description = ""
        Map(2, 7).North = True
        Map(2, 7).East = True
        Map(2, 7).South = True
        Map(2, 7).West = True
        Map(2, 7).items = ""

        Map(2, 8).Name = ""
        Map(2, 8).Description = ""
        Map(2, 8).North = True
        Map(2, 8).East = True
        Map(2, 8).South = True
        Map(2, 8).West = True
        Map(2, 8).items = ""

        Map(2, 9).Name = ""
        Map(2, 9).Description = ""
        Map(2, 9).North = True
        Map(2, 9).East = True
        Map(2, 9).South = True
        Map(2, 9).West = True
        Map(2, 9).items = ""

        Map(2, 10).Name = ""
        Map(2, 10).Description = ""
        Map(2, 10).North = True
        Map(2, 10).East = True
        Map(2, 10).South = False
        Map(2, 10).West = True
        Map(2, 10).items = ""

        'start of 3

        Map(3, 0).Name = ""
        Map(3, 0).Description = ""
        Map(3, 0).north = false
        Map(3, 0).East = True
        Map(3, 0).South = True
        Map(3, 0).West = True
        Map(3, 0).items = ""

        Map(3, 1).Name = ""
        Map(3, 1).Description = ""
        Map(3, 1).North = False
        Map(3, 1).East = True
        Map(3, 1).South = True
        Map(3, 1).West = True
        Map(3, 1).items = ""

        Map(3, 2).Name = ""
        Map(3, 2).Description = ""
        Map(3, 2).North = True
        Map(3, 2).East = True
        Map(3, 2).South = True
        Map(3, 2).West = True
        Map(3, 2).items = ""

        Map(3, 3).Name = ""
        Map(3, 3).Description = ""
        Map(3, 3).North = True
        Map(3, 3).East = True
        Map(3, 3).South = True
        Map(3, 3).West = True
        Map(3, 3).items = ""

        Map(3, 4).Name = ""
        Map(3, 4).Description = ""
        Map(3, 4).North = True
        Map(3, 4).East = True
        Map(3, 4).South = True
        Map(3, 4).West = True
        Map(3, 4).items = ""

        Map(3, 5).Name = ""
        Map(3, 5).Description = ""
        Map(3, 5).North = True
        Map(3, 5).East = True
        Map(3, 5).South = True
        Map(3, 5).West = True
        Map(3, 5).items = ""

        Map(3, 6).Name = ""
        Map(3, 6).Description = ""
        Map(3, 6).North = True
        Map(3, 6).East = True
        Map(3, 6).South = True
        Map(3, 6).West = True
        Map(3, 6).items = ""

        Map(3, 7).Name = ""
        Map(3, 7).Description = ""
        Map(3, 7).North = True
        Map(3, 7).East = True
        Map(3, 7).South = True
        Map(3, 7).West = True
        Map(3, 7).items = ""

        Map(3, 8).Name = ""
        Map(3, 8).Description = ""
        Map(3, 8).North = True
        Map(3, 8).East = True
        Map(3, 8).South = True
        Map(3, 8).West = True
        Map(3, 8).items = ""

        Map(3, 9).Name = ""
        Map(3, 9).Description = ""
        Map(3, 9).North = True
        Map(3, 9).East = True
        Map(3, 9).South = True
        Map(3, 9).West = True
        Map(3, 9).items = ""

        Map(3, 10).Name = ""
        Map(3, 10).Description = ""
        Map(3, 10).North = True
        Map(3, 10).East = True
        Map(3, 10).South = False
        Map(3, 10).West = True
        Map(3, 10).items = ""

        'start of 4

        Map(4, 0).Name = ""
        Map(4, 0).Description = ""
        Map(4, 0).North = False
        Map(4, 0).East = True
        Map(4, 0).South = True
        Map(4, 0).West = True
        Map(4, 0).items = ""

        Map(4, 1).Name = ""
        Map(4, 1).Description = ""
        Map(4, 1).North = False
        Map(4, 1).East = True
        Map(4, 1).South = True
        Map(4, 1).West = True
        Map(4, 1).items = ""

        Map(4, 2).Name = ""
        Map(4, 2).Description = ""
        Map(4, 2).North = True
        Map(4, 2).East = True
        Map(4, 2).South = True
        Map(4, 2).West = True
        Map(4, 2).items = ""

        Map(4, 3).Name = ""
        Map(4, 3).Description = ""
        Map(4, 3).North = True
        Map(4, 3).East = True
        Map(4, 3).South = True
        Map(4, 3).West = True
        Map(4, 3).items = ""

        Map(4, 4).Name = ""
        Map(4, 4).Description = ""
        Map(4, 4).North = True
        Map(4, 4).East = True
        Map(4, 4).South = True
        Map(4, 4).West = True
        Map(4, 4).items = ""

        Map(4, 5).Name = ""
        Map(4, 5).Description = ""
        Map(4, 5).North = True
        Map(4, 5).East = True
        Map(4, 5).South = True
        Map(4, 5).West = True
        Map(4, 5).items = ""

        Map(4, 6).Name = ""
        Map(4, 6).Description = ""
        Map(4, 6).North = True
        Map(4, 6).East = True
        Map(4, 6).South = True
        Map(4, 6).West = True
        Map(4, 6).items = ""

        Map(4, 7).Name = ""
        Map(4, 7).Description = ""
        Map(4, 7).North = True
        Map(4, 7).East = True
        Map(4, 7).South = True
        Map(4, 7).West = True
        Map(4, 7).items = ""

        Map(4, 8).Name = ""
        Map(4, 8).Description = ""
        Map(4, 8).North = True
        Map(4, 8).East = True
        Map(4, 8).South = True
        Map(4, 8).West = True
        Map(4, 8).items = ""

        Map(4, 9).Name = ""
        Map(4, 9).Description = ""
        Map(4, 9).North = True
        Map(4, 9).East = True
        Map(4, 9).South = True
        Map(4, 9).West = True
        Map(4, 9).items = ""

        Map(3, 10).Name = ""
        Map(3, 10).Description = ""
        Map(3, 10).North = True
        Map(3, 10).East = True
        Map(3, 10).South = False
        Map(3, 10).West = True
        Map(3, 10).items = ""

        'start of 5

        Map(5, 0).Name = ""
        Map(5, 0).Description = ""
        Map(5, 0).North = False
        Map(5, 0).East = True
        Map(5, 0).South = True
        Map(5, 0).West = True
        Map(5, 0).items = ""

        Map(5, 1).Name = ""
        Map(5, 1).Description = ""
        Map(5, 1).North = False
        Map(5, 1).East = True
        Map(5, 1).South = True
        Map(5, 1).West = True
        Map(5, 1).items = ""

        Map(5, 2).Name = ""
        Map(5, 2).Description = ""
        Map(5, 2).North = True
        Map(5, 2).East = True
        Map(5, 2).South = True
        Map(5, 2).West = True
        Map(5, 2).items = ""

        Map(5, 3).Name = ""
        Map(5, 3).Description = ""
        Map(5, 3).North = True
        Map(5, 3).East = True
        Map(5, 3).South = True
        Map(5, 3).West = True
        Map(5, 3).items = ""

        Map(5, 4).Name = ""
        Map(5, 4).Description = ""
        Map(5, 4).North = True
        Map(5, 4).East = True
        Map(5, 4).South = True
        Map(5, 4).West = True
        Map(5, 4).items = ""

        Map(5, 5).Name = ""
        Map(5, 5).Description = ""
        Map(5, 5).North = True
        Map(5, 5).East = True
        Map(5, 5).South = True
        Map(5, 5).West = True
        Map(5, 5).items = ""

        Map(5, 6).Name = ""
        Map(5, 6).Description = ""
        Map(5, 6).North = True
        Map(5, 6).East = True
        Map(5, 6).South = True
        Map(5, 6).West = True
        Map(5, 6).items = ""

        Map(5, 7).Name = ""
        Map(5, 7).Description = ""
        Map(5, 7).North = True
        Map(5, 7).East = True
        Map(5, 7).South = True
        Map(5, 7).West = True
        Map(5, 7).items = ""

        Map(5, 8).Name = ""
        Map(5, 8).Description = ""
        Map(5, 8).North = True
        Map(5, 8).East = True
        Map(5, 8).South = True
        Map(5, 8).West = True
        Map(5, 8).items = ""

        Map(5, 9).Name = ""
        Map(5, 9).Description = ""
        Map(5, 9).North = True
        Map(5, 9).East = True
        Map(5, 9).South = True
        Map(5, 9).West = True
        Map(5, 9).items = ""

        Map(5, 10).Name = ""
        Map(5, 10).Description = ""
        Map(5, 10).North = True
        Map(5, 10).East = True
        Map(5, 10).South = False
        Map(5, 10).West = True
        Map(5, 10).items = ""

        'start of 6

        Map(6, 0).Name = ""
        Map(6, 0).Description = ""
        Map(6, 0).North = False
        Map(6, 0).East = True
        Map(6, 0).South = True
        Map(6, 0).West = True
        Map(6, 0).items = ""

        Map(6, 1).Name = ""
        Map(6, 1).Description = ""
        Map(6, 1).North = False
        Map(6, 1).East = True
        Map(6, 1).South = True
        Map(6, 1).West = True
        Map(6, 1).items = ""

        Map(6, 2).Name = ""
        Map(6, 2).Description = ""
        Map(6, 2).North = True
        Map(6, 2).East = True
        Map(6, 2).South = True
        Map(6, 2).West = True
        Map(6, 2).items = ""

        Map(6, 3).Name = ""
        Map(6, 3).Description = ""
        Map(6, 3).North = True
        Map(6, 3).East = True
        Map(6, 3).South = True
        Map(6, 3).West = True
        Map(6, 3).items = ""

        Map(6, 4).Name = ""
        Map(6, 4).Description = ""
        Map(6, 4).North = True
        Map(6, 4).East = True
        Map(6, 4).South = True
        Map(6, 4).West = True
        Map(6, 4).items = ""

        Map(6, 5).Name = ""
        Map(6, 5).Description = ""
        Map(6, 5).North = True
        Map(6, 5).East = True
        Map(6, 5).South = True
        Map(6, 5).West = True
        Map(6, 5).items = ""

        Map(6, 6).Name = ""
        Map(6, 6).Description = ""
        Map(6, 6).North = True
        Map(6, 6).East = True
        Map(6, 6).South = True
        Map(6, 6).West = True
        Map(6, 6).items = ""

        Map(6, 7).Name = ""
        Map(6, 7).Description = ""
        Map(6, 7).North = True
        Map(6, 7).East = True
        Map(6, 7).South = True
        Map(6, 7).West = True
        Map(6, 7).items = ""

        Map(6, 8).Name = ""
        Map(6, 8).Description = ""
        Map(6, 8).North = True
        Map(6, 8).East = True
        Map(6, 8).South = True
        Map(6, 8).West = True
        Map(6, 8).items = ""

        Map(6, 9).Name = ""
        Map(6, 9).Description = ""
        Map(6, 9).North = True
        Map(6, 9).East = True
        Map(6, 9).South = True
        Map(6, 9).West = True
        Map(6, 9).items = ""

        Map(6, 10).Name = ""
        Map(6, 10).Description = ""
        Map(6, 10).North = True
        Map(6, 10).East = True
        Map(6, 10).South = False
        Map(6, 10).West = True
        Map(6, 10).items = ""

        'start of 7

        Map(7, 0).Name = ""
        Map(7, 0).Description = ""
        Map(7, 0).North = False
        Map(7, 0).East = True
        Map(7, 0).South = True
        Map(7, 0).West = True
        Map(7, 0).items = ""

        Map(7, 1).Name = ""
        Map(7, 1).Description = ""
        Map(7, 1).North = False
        Map(7, 1).East = True
        Map(7, 1).South = True
        Map(7, 1).West = True
        Map(7, 1).items = ""

        Map(7, 2).Name = ""
        Map(7, 2).Description = ""
        Map(7, 2).North = True
        Map(7, 2).East = True
        Map(7, 2).South = True
        Map(7, 2).West = True
        Map(7, 2).items = ""

        Map(7, 3).Name = ""
        Map(7, 3).Description = ""
        Map(7, 3).North = True
        Map(7, 3).East = True
        Map(7, 3).South = True
        Map(7, 3).West = True
        Map(7, 3).items = ""

        Map(7, 4).Name = ""
        Map(7, 4).Description = ""
        Map(7, 4).North = True
        Map(7, 4).East = True
        Map(7, 4).South = True
        Map(7, 4).West = True
        Map(7, 4).items = ""

        Map(7, 5).Name = ""
        Map(7, 5).Description = ""
        Map(7, 5).North = True
        Map(7, 5).East = True
        Map(7, 5).South = True
        Map(7, 5).West = True
        Map(7, 5).items = ""

        Map(7, 6).Name = ""
        Map(7, 6).Description = ""
        Map(7, 6).North = True
        Map(7, 6).East = True
        Map(7, 6).South = True
        Map(7, 6).West = True
        Map(7, 6).items = ""

        Map(7, 7).Name = ""
        Map(7, 7).Description = ""
        Map(7, 7).North = True
        Map(7, 7).East = True
        Map(7, 7).South = True
        Map(7, 7).West = True
        Map(7, 7).items = ""

        Map(7, 8).Name = ""
        Map(7, 8).Description = ""
        Map(7, 8).North = True
        Map(7, 8).East = True
        Map(7, 8).South = True
        Map(7, 8).West = True
        Map(7, 8).items = ""

        Map(7, 9).Name = ""
        Map(7, 9).Description = ""
        Map(7, 9).North = True
        Map(7, 9).East = True
        Map(7, 9).South = True
        Map(7, 9).West = True
        Map(7, 9).items = ""

        Map(7, 10).Name = ""
        Map(7, 10).Description = ""
        Map(7, 10).North = True
        Map(7, 10).East = True
        Map(7, 10).South = False
        Map(7, 10).West = True
        Map(7, 10).items = ""

        'start of 8

        Map(8, 0).Name = ""
        Map(8, 0).Description = ""
        Map(8, 0).North = False
        Map(8, 0).East = True
        Map(8, 0).South = True
        Map(8, 0).West = True
        Map(8, 0).items = ""

        Map(8, 1).Name = ""
        Map(8, 1).Description = ""
        Map(8, 1).North = False
        Map(8, 1).East = True
        Map(8, 1).South = True
        Map(8, 1).West = True
        Map(8, 1).items = ""

        Map(8, 2).Name = ""
        Map(8, 2).Description = ""
        Map(8, 2).North = True
        Map(8, 2).East = True
        Map(8, 2).South = True
        Map(8, 2).West = True
        Map(8, 2).items = ""

        Map(8, 3).Name = ""
        Map(8, 3).Description = ""
        Map(8, 3).North = True
        Map(8, 3).East = True
        Map(8, 3).South = True
        Map(8, 3).West = True
        Map(8, 3).items = ""

        Map(8, 4).Name = ""
        Map(8, 4).Description = ""
        Map(8, 4).North = True
        Map(8, 4).East = True
        Map(8, 4).South = True
        Map(8, 4).West = True
        Map(8, 4).items = ""

        Map(8, 5).Name = ""
        Map(8, 5).Description = ""
        Map(8, 5).North = True
        Map(8, 5).East = True
        Map(8, 5).South = True
        Map(8, 5).West = True
        Map(8, 5).items = ""

        Map(8, 6).Name = ""
        Map(8, 6).Description = ""
        Map(8, 6).North = True
        Map(8, 6).East = True
        Map(8, 6).South = True
        Map(8, 6).West = True
        Map(8, 6).items = ""

        Map(8, 7).Name = ""
        Map(8, 7).Description = ""
        Map(8, 7).North = True
        Map(8, 7).East = True
        Map(8, 7).South = True
        Map(8, 7).West = True
        Map(8, 7).items = ""

        Map(8, 8).Name = ""
        Map(8, 8).Description = ""
        Map(8, 8).North = True
        Map(8, 8).East = True
        Map(8, 8).South = True
        Map(8, 8).West = True
        Map(8, 8).items = ""

        Map(8, 9).Name = ""
        Map(8, 9).Description = ""
        Map(8, 9).North = True
        Map(8, 9).East = True
        Map(8, 9).South = True
        Map(8, 9).West = True
        Map(8, 9).items = ""

        Map(8, 10).Name = ""
        Map(8, 10).Description = ""
        Map(8, 10).North = True
        Map(8, 10).East = True
        Map(8, 10).South = False
        Map(8, 10).West = True
        Map(8, 10).items = ""

        'start of 9

        Map(9, 0).Name = ""
        Map(9, 0).Description = ""
        Map(9, 0).North = False
        Map(9, 0).East = True
        Map(9, 0).South = True
        Map(9, 0).West = True
        Map(9, 0).items = ""

        Map(9, 1).Name = ""
        Map(9, 1).Description = ""
        Map(9, 1).North = False
        Map(9, 1).East = True
        Map(9, 1).South = True
        Map(9, 1).West = True
        Map(9, 1).items = ""

        Map(9, 2).Name = ""
        Map(9, 2).Description = ""
        Map(9, 2).North = True
        Map(9, 2).East = True
        Map(9, 2).South = True
        Map(9, 2).West = True
        Map(9, 2).items = ""

        Map(9, 3).Name = ""
        Map(9, 3).Description = ""
        Map(9, 3).North = True
        Map(9, 3).East = True
        Map(9, 3).South = True
        Map(9, 3).West = True
        Map(9, 3).items = ""

        Map(9, 4).Name = ""
        Map(9, 4).Description = ""
        Map(9, 4).North = True
        Map(9, 4).East = True
        Map(9, 4).South = True
        Map(9, 4).West = True
        Map(9, 4).items = ""

        Map(9, 5).Name = ""
        Map(9, 5).Description = ""
        Map(9, 5).North = True
        Map(9, 5).East = True
        Map(9, 5).South = True
        Map(9, 5).West = True
        Map(9, 5).items = ""

        Map(9, 6).Name = ""
        Map(9, 6).Description = ""
        Map(9, 6).North = True
        Map(9, 6).East = True
        Map(9, 6).South = True
        Map(9, 6).West = True
        Map(9, 6).items = ""

        Map(9, 7).Name = ""
        Map(9, 7).Description = ""
        Map(9, 7).North = True
        Map(9, 7).East = True
        Map(9, 7).South = True
        Map(9, 7).West = True
        Map(9, 7).items = ""

        Map(9, 8).Name = ""
        Map(9, 8).Description = ""
        Map(9, 8).North = True
        Map(9, 8).East = True
        Map(9, 8).South = True
        Map(9, 8).West = True
        Map(9, 8).items = ""

        Map(9, 9).Name = ""
        Map(9, 9).Description = ""
        Map(9, 9).North = True
        Map(9, 9).East = True
        Map(9, 9).South = True
        Map(9, 9).West = True
        Map(9, 9).items = ""

        Map(9, 10).Name = ""
        Map(9, 10).Description = ""
        Map(9, 10).North = True
        Map(9, 10).East = True
        Map(9, 10).South = False
        Map(9, 10).West = True
        Map(9, 10).items = ""

        'start of 10

        Map(10, 0).Name = ""
        Map(10, 0).Description = ""
        Map(10, 0).North = False
        Map(10, 0).East = False
        Map(10, 0).South = True
        Map(10, 0).West = True
        Map(10, 0).items = ""

        Map(10, 1).Name = ""
        Map(10, 1).Description = ""
        Map(10, 1).North = False
        Map(10, 1).East = False
        Map(10, 1).South = True
        Map(10, 1).West = True
        Map(10, 1).items = ""

        Map(10, 2).Name = ""
        Map(10, 2).Description = ""
        Map(10, 2).North = True
        Map(10, 2).East = False
        Map(10, 2).South = True
        Map(10, 2).West = True
        Map(10, 2).items = ""

        Map(10, 3).Name = ""
        Map(10, 3).Description = ""
        Map(10, 3).North = True
        Map(10, 3).East = False
        Map(10, 3).South = True
        Map(10, 3).West = True
        Map(10, 3).items = ""

        Map(10, 4).Name = ""
        Map(10, 4).Description = ""
        Map(10, 4).North = True
        Map(10, 4).East = False
        Map(10, 4).South = True
        Map(10, 4).West = True
        Map(10, 4).items = ""

        Map(10, 5).Name = ""
        Map(10, 5).Description = ""
        Map(10, 5).North = True
        Map(10, 5).East = False
        Map(10, 5).South = True
        Map(10, 5).West = True
        Map(10, 5).items = ""

        Map(10, 6).Name = ""
        Map(10, 6).Description = ""
        Map(10, 6).North = True
        Map(10, 6).East = False
        Map(10, 6).South = True
        Map(10, 6).West = True
        Map(10, 6).items = ""

        Map(10, 7).Name = ""
        Map(10, 7).Description = ""
        Map(10, 7).North = True
        Map(10, 7).East = False
        Map(10, 7).South = True
        Map(10, 7).West = True
        Map(10, 7).items = ""

        Map(10, 8).Name = ""
        Map(10, 8).Description = ""
        Map(10, 8).North = True
        Map(10, 8).East = False
        Map(10, 8).South = True
        Map(10, 8).West = True
        Map(10, 8).items = ""

        Map(10, 9).Name = ""
        Map(10, 9).Description = ""
        Map(10, 9).North = True
        Map(10, 9).East = False
        Map(10, 9).South = True
        Map(10, 9).West = True
        Map(10, 9).items = ""

        Map(10, 10).Name = ""
        Map(10, 10).Description = ""
        Map(10, 10).North = True
        Map(10, 10).East = False
        Map(10, 10).South = False
        Map(10, 10).West = True
        Map(10, 10).items = ""

        inp()
    End Sub

    Sub boss()
        Dim path As String
        Dim choice As String
        Dim health As Integer = 100

        Console.WriteLine()
        Console.WriteLine(bar)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("                                        " & ", You come across a forest. The entrance to the forest has 2 paths ")
        Console.WriteLine(" one Is thick With brambles And the other Is clear but the trees wind In a way that Is almost contorting your perspective Of how far the forest extends. ")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(bar)
        For x = 0 To 29
            Console.WriteLine()
        Next
        Console.WriteLine(bar)
        Console.WriteLine(" Health " & health & "/100 Press 1 or 2 to select your path: ")
        Console.WriteLine(bar)
        Console.WriteLine()
        path = Console.ReadLine

        If path = "1" Then
            Console.Clear()
            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("  Once you've walked far enough into the brambles, a bright light appears along the path and as it dissapates a pair of wings appear floating in the air.")
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine()
            Console.WriteLine("                                                                           The Angel")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("   ""Pleadge you alleigance to my master and I shall grant you holy guidance and the power to smite those who block your path along this grand adventure."" ")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine(bar)
            For x = 0 To 5
                Console.WriteLine()
            Next
            Console.WriteLine("                                                .                                                            ,")
            Console.WriteLine("                                                |`.                                                        ,'|")
            Console.WriteLine("                                                \_`-._                                                  _,-'_/")
            Console.WriteLine("                                               ./ \-._`-._                                          _,-'_,-/ \,")
            Console.WriteLine("                                               \._/._ `._>`-.__                                __,-'<_,' _,\_,/")
            Console.WriteLine("                                               /_ \_.`-._\_-._ `--__                      __--' _,-_/_,-',_/ _\")
            Console.WriteLine("                                                /._`\_./ _`_./`.-._ `-.                ,-' _,-,'\,_'_ \,_/'_,\")
            Console.WriteLine("                                                 \._`/ _/ _`_./  _/`\_ `.            ,' _/'\_  \,_'_ \_ \'_,/")
            Console.WriteLine("                                                  /._`/ _/ _`_./` _/ `\_ `\_      _/' _/' \_ '\,_'_ \_ \'_,\")
            Console.WriteLine("                                                   \._`/ _/ _`_./` __/  >.  `-.,-'  ,<  \__ '\,_'_ \_ \'_,/")
            Console.WriteLine("                                                     /_`/._/._`_./` __.`.-\_.-`'-._/-,',__ '\,_'_,\_,\'_\")
            Console.WriteLine("                                                           `\._`_./`\._/_/'        `\_\_,/'\,_'_,/'")
            For x = 0 To 9
                Console.WriteLine()
            Next
            Console.WriteLine(bar)
            Console.WriteLine(" Health " & health & "/100 Press y or n to accept or decline the Angels offer: ")
            Console.WriteLine(bar)
            Console.WriteLine()
            choice = Console.ReadLine
        Else
            Console.Clear()
            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("  Once you've walked far enough into the brambles, a bright light appears along the path and as it dissapates, an imp appears floating in the air.")
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine()
            Console.WriteLine("                                                                          The Daemon")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("  ""Pleadge you alleigance to my master and I shall grant you profane guidance and the power to smite those who block your path along this grand adventure."" ")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine(bar)
            For x = 0 To 5
                Console.WriteLine()
            Next
            Console.WriteLine("                                                                              ,-.")
            Console.WriteLine("                                                         ___,---.__          /'|`\          __,---,___")
            Console.WriteLine("                                                      ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.")
            Console.WriteLine("                                                    ,'        |           ~'\     /`~           |        `.")
            Console.WriteLine("                                                   /      ___//              `. ,'          ,  , \___      \")
            Console.WriteLine("                                                  |    ,-'   `-.__   _         |        ,    __,-'   `-.    |")
            Console.WriteLine("                                                  |   /          /\_  `   .    |    ,      _/\          \   |")
            Console.WriteLine("                                                  \  |           \ \`-.___ \   |   / ___,-'/ /           |  /")
            Console.Write("                                                   \  \           | `._   `\\  |  //' ")
            Console.ForegroundColor = ConsoleColor.Blue
            Console.Write(".")
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine(" _,' |           /  /")
            Console.WriteLine("                                                    `-.\         /'  _ `---'' , . ``---' _  `\         /,-'")
            Console.WriteLine("                                                       ``       /     \    ,='/ \`=.    /     \       ''")
            Console.WriteLine("                                                               |__   /|\_,--.,-.--,--._/|\   __|")
            Console.WriteLine("                                                               /  `./  \\`\ |  |  | /,//' \,'  \")
            Console.WriteLine("                                                              /   /     ||--+--|--+-/-|     \   \")
            Console.WriteLine("                                                             |   |     /'\_\_\ | /_/_/`\     |   |")
            Console.WriteLine("                                                              \   \__, \_     `~'     _/ .__/   /")
            Console.WriteLine("                                                               `-._,-'   `-._______,-'   `-._,-'")
            For x = 0 To 5
                Console.WriteLine()
            Next

            Console.WriteLine(bar)
            Console.WriteLine(" Health " & health & "/100 Press y or n to accept or decline the Daemons offer: ")
            Console.WriteLine(bar)
            Console.WriteLine()
            choice = Console.ReadLine
        End If

    End Sub

End Module
