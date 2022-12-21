Imports System
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Math
Imports System.Reflection.Metadata.Ecma335
Imports System.IO
Imports Rpg.Functions

Structure Location
    Dim Name As String
    Dim Description As String
    Dim direction As String 'new----------------------------------------------------------------
    Dim North, East, South, West As Boolean
    Dim i_num As Integer
    Dim Npcs As String
End Structure

Structure Item
    Dim Name As String

End Structure

Structure self
    Dim Pname As String
    Dim pclass As String
    Dim hp As Integer
    Dim mp As Integer
    Dim status_effects() As String
End Structure

Structure Inventory
    Dim item_number As Integer
    Dim item_name As String
    Dim item_desc As String
    Dim effect As String
    Dim exists As Boolean
    Dim X_loc As Integer
    Dim Y_loc As Integer
End Structure

Module game
    '#############################TO DO LIST#############################
    '
    'Implament key presses and a new bottom bar ui to select actions
    '
    '
    Dim Bar As String = "+----------------------------------------------------------------------------------------------------------------------------------------------------------+"
    Public ended As Boolean = False
    Public playerx, playery As Integer
    Dim numofItems As Integer



    Public Map(10, 10) As Location
    Public Inv(7) As Inventory
    Public Items(5) As Item
    Dim Name As self



    Sub Help_menu()
        Dim x As String
        Console.Clear()
        Console.WriteLine(Bar)
        Console.WriteLine("                                                  Type a command such as 'move' then 'left' to nagivate the map .")
        Console.WriteLine("                                               Inputs such as 'look' or 'examine' will let you interact with rooms.")
        Console.WriteLine("                                                           Please ensure to type in lowercase for ease.")
        Console.WriteLine(Bar)
        Console.WriteLine("                                                               Please select an option to continue.     ")
        Console.WriteLine(Bar)
        Console.WriteLine("                                                                            .: Play :.                  ")
        Console.WriteLine("                                                                            .: Help :.                  ")
        Console.WriteLine("                                                                            .: Quit :.                  ")
        x = Console.ReadLine()
        title_screen_options(x)
    End Sub
    Sub Title_screen()
        Dim y As String
        Console.WriteLine()
        Console.WriteLine(Bar)
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
        Console.WriteLine("                                                                              .::.                  ")
        Console.WriteLine("                                                                           .: Play :.                  ")
        Console.WriteLine("                                                                         .: New Game :.                  ")
        Console.WriteLine("                                                                           :: Help ::                  ")
        Console.WriteLine("                                                                          .:: Quit ::.                  ")
        Console.WriteLine(Bar)
        Console.WriteLine()
        Console.Write("> ")
        y = Console.ReadLine()
        title_screen_options(y)
    End Sub

    'display the inventory screen
    Sub Bag()
        Dim p As Integer
        p = 1

        Dim chosen_num As String
        Dim b As Integer
        Console.Clear()
        Console.WriteLine("##INVENTORY_LIST##")
        Console.WriteLine()
        For x = 0 To 7
            If Inv(x).X_loc = -1 Then
                Console.Write(p & ". ")
                Console.WriteLine(Inv(x).item_name)
                p = p + 1
            End If

        Next

        Console.WriteLine()
        Console.WriteLine("Choose one with a number or exit")
        Console.Write("> ")
        chosen_num = Console.ReadLine()
        chosen_num = chosen_num.ToLower
        b = CInt(chosen_num)

        Try
            If Name.pclass = "warrior" Then

                Console.WriteLine(Inv(b - 1).item_desc)
                Console.WriteLine()
                Console.WriteLine()
            ElseIf Name.pclass = "mage" Then


                Console.WriteLine(Inv(b - 1).item_desc)
                Console.WriteLine()
                Console.WriteLine()


            ElseIf Name.pclass = "rogue" Then


                Console.WriteLine(Inv(b - 1).item_desc)
                Console.WriteLine()
                Console.WriteLine()

            End If
        Catch ex As Exception

        End Try


        Inp()
    End Sub

    'Print the location and wait for an input 
    Sub Inp()
        Dim input As String

        Console.WriteLine(print_location(playerx, playery))
        Console.WriteLine()
        Console.Write("> ")
        input = Console.ReadLine()
        Console.WriteLine(commands(input))
        Console.WriteLine()
    End Sub

    'read wright to save file
    Sub Save()

        Dim Path As String = "C:\computer science\Save.txt"

        Dim dlol As String

        File.Delete("C:\computer science\Save.txt")

        dlol = "lol"
        'dElon = "ELON"
        'dGate = "WAS MADE LONGER"
        'dDate = "© James Oxley 2022"
        FileOpen(1, Path, OpenMode.Output)

        PrintLine(1, CStr(Name.Pname))
        PrintLine(1, CStr(Name.pclass))
        PrintLine(1, CStr(playerx))
        PrintLine(1, CStr(playery))

        'PrintLine(1, name.pclass)
        'PrintLine(1, dDate)
        For x = 0 To numofItems
            PrintLine(1, Inv(x).item_name)
            PrintLine(1, Inv(x).X_loc)
            PrintLine(1, Inv(x).Y_loc)
        Next


        FileClose(1)

        If ended = True Then
            End
        End If



    End Sub
    Sub Read()


        Dim Path As String = "C:\computer science\Save.txt"
        Dim y As String
        Dim p() As String
        Dim c As Integer = 0
        Dim slot As Integer = 0


        'FileOpen(1, Path, OpenMode.Input)

        p = File.ReadAllLines(Path)
            Console.WriteLine(p(1))
        'Read all the data from the file and use it to set variables


        y = CStr(p(c))
        If c = 0 Then
            Name.Pname = y
            c = c + 1
        ElseIf c = 1 Then
            Name.pclass = y
            c = c + 1
        ElseIf c = 2 Then
            playerx = CInt(p(2))
            Console.WriteLine(playerx & "x")
            c = c + 1
        ElseIf c = 3 Then
            playery = CInt(p(3))

            Console.WriteLine(playery)
            c = c + 1
        ElseIf c >= 4 Then

            For i = 4 To p.Length
                Inv(slot).item_name = CStr(p(c))
                Console.WriteLine(Inv(slot).item_name)
                Inv(slot).X_loc = CInt(p(c + 1))
                Console.WriteLine(Inv(slot).X_loc)
                Inv(slot).Y_loc = CInt(p(c + 2))
                Console.WriteLine(Inv(slot).Y_loc)
                c = c + 3
                slot = slot + 1
            Next

        End If









        FileClose(1)





    End Sub

    'Goes through the game starting process with the player
    Sub New_game()
        Dim a As String
        Console.Clear()
        Console.WriteLine("what's your name brave adventurer? ")
        Name.Pname = Console.ReadLine()
        Console.Clear()
        Console.WriteLine("####CLASS_SELECTION####")
        Console.WriteLine("1. Warrior")
        Console.WriteLine("2. Mage")
        Console.WriteLine("3. Rogue")
        Console.WriteLine()
        Console.WriteLine("select what class you want to play")
        Console.WriteLine()
        Console.Write("> ")
        a = Console.ReadLine()
        a = a.ToLower
        If a.Contains("1") Or a.Contains("warrior") Then
            Name.hp = 100
            Name.mp = 0
            Name.pclass = "warrior"
            Console.Clear()
        ElseIf a.Contains("2") Or a.Contains("mage") Then
            Name.hp = 60
            Name.mp = 40
            Name.pclass = "mage"

            Console.Clear()
        ElseIf a.Contains("3") Or a.Contains("rogue") Then
            Name.hp = 80
            Name.mp = 20
            Name.pclass = "rogue"

            Console.Clear()
        Else
            Console.WriteLine("Your selection was invalid, automatically picking warrior for you.")
            Name.hp = 100
            Name.mp = 0
            Name.pclass = "warrior"
            Console.Clear()
        End If








        playerx = 0
        playery = 1
        Save()
        start()
    End Sub


    Sub Main()

        Console.Title() = "Rpg 5 hrs in Project"
        Console.WindowHeight = 30
        Console.WindowWidth = 156
        Title_screen()

    End Sub
    Sub start()


        Map(0, 0).Name = "Living room"
        Map(0, 0).Description = ""
        Map(0, 1).direction = " East, South." 'new and needs to be replicated for every tile---------------------------------------------
        Map(0, 0).North = False
        Map(0, 0).East = True
        Map(0, 0).South = True
        Map(0, 0).West = False


        Map(0, 1).Name = "James's front garden"
        Map(0, 1).Description = "You're stood south of the door to the house and north of the path to the village centre" & vbCrLf & "To your left is rock and a wall to the house is on your right"
        Map(0, 1).direction = "Directions: North, South."
        Map(0, 1).North = True
        Map(0, 1).East = False
        Map(0, 1).South = True
        Map(0, 1).West = False

        Map(0, 2).Name = "Pathway"
        Map(0, 2).Description = "stretches downawards"
        Map(0, 1).direction = "Directions: North, East, South."
        Map(0, 2).North = True
        Map(0, 2).East = True
        Map(0, 2).South = True
        Map(0, 2).West = False


        Map(0, 3).Name = "Pathway"
        Map(0, 3).Description = "Leads down to a nearby sign"
        Map(0, 1).direction = "North, East, South."
        Map(0, 3).North = True
        Map(0, 3).East = True
        Map(0, 3).South = True
        Map(0, 3).West = False


        Map(0, 4).Name = "Crossroad"
        Map(0, 4).Description = "Sign reads " & vbCrLf & "upwards towards james's house" & vbCrLf & "right to village centre"
        Map(0, 1).direction = "North, East."
        Map(0, 4).North = True
        Map(0, 4).East = True
        Map(0, 4).South = False
        Map(0, 4).West = False


        Map(0, 5).Name = ""
        Map(0, 5).Description = ""
        Map(0, 5).North = True
        Map(0, 5).East = True
        Map(0, 5).South = True
        Map(0, 5).West = False


        Map(0, 6).Name = ""
        Map(0, 6).Description = ""
        Map(0, 6).North = True
        Map(0, 6).East = True
        Map(0, 6).South = True
        Map(0, 6).West = False


        Map(0, 7).Name = ""
        Map(0, 7).Description = ""
        Map(0, 7).North = True
        Map(0, 7).East = True
        Map(0, 7).South = True
        Map(0, 7).West = False


        Map(0, 8).Name = ""
        Map(0, 8).Description = ""
        Map(0, 8).North = True
        Map(0, 8).East = True
        Map(0, 8).South = True
        Map(0, 8).West = False


        Map(0, 9).Name = ""
        Map(0, 9).Description = ""
        Map(0, 9).North = True
        Map(0, 9).East = True
        Map(0, 9).South = True
        Map(0, 9).West = False


        Map(0, 10).Name = ""
        Map(0, 10).Description = ""
        Map(0, 10).North = True
        Map(0, 10).East = True
        Map(0, 10).South = False
        Map(0, 10).West = False


        'start of 1

        Map(1, 0).Name = ""
        Map(1, 0).Description = ""
        Map(1, 0).North = False
        Map(1, 0).East = True
        Map(1, 0).South = True
        Map(1, 0).West = True


        Map(1, 1).Name = ""
        Map(1, 1).Description = ""
        Map(1, 1).North = True
        Map(1, 1).East = True
        Map(1, 1).South = True
        Map(1, 1).West = True


        Map(1, 2).Name = ""
        Map(1, 2).Description = ""
        Map(1, 2).North = True
        Map(1, 2).East = True
        Map(1, 2).South = True
        Map(1, 2).West = True


        Map(1, 3).Name = ""
        Map(1, 3).Description = ""
        Map(1, 3).North = True
        Map(1, 3).East = True
        Map(1, 3).South = True
        Map(1, 3).West = True

        Map(1, 4).Name = ""
        Map(1, 4).Description = ""
        Map(1, 4).North = True
        Map(1, 4).East = True
        Map(1, 4).South = True
        Map(1, 4).West = True

        Map(1, 5).Name = ""
        Map(1, 5).Description = ""
        Map(1, 5).North = True
        Map(1, 5).East = True
        Map(1, 5).South = True
        Map(1, 5).West = True

        Map(1, 6).Name = ""
        Map(1, 6).Description = ""
        Map(1, 6).North = True
        Map(1, 6).East = True
        Map(1, 6).South = True
        Map(1, 6).West = True

        Map(1, 7).Name = ""
        Map(1, 7).Description = ""
        Map(1, 7).North = True
        Map(1, 7).East = True
        Map(1, 7).South = True
        Map(1, 7).West = True

        Map(1, 8).Name = ""
        Map(1, 8).Description = ""
        Map(1, 8).North = True
        Map(1, 8).East = True
        Map(1, 8).South = True
        Map(1, 8).West = True

        Map(1, 9).Name = ""
        Map(1, 9).Description = ""
        Map(1, 9).North = True
        Map(1, 9).East = True
        Map(1, 9).South = True
        Map(1, 9).West = True

        Map(1, 10).Name = ""
        Map(1, 10).Description = ""
        Map(1, 10).North = True
        Map(1, 10).East = True
        Map(1, 10).South = False
        Map(1, 10).West = True

        'start of 2 

        Map(2, 0).Name = ""
        Map(2, 0).Description = ""
        Map(2, 0).North = False
        Map(2, 0).East = True
        Map(2, 0).South = True
        Map(2, 0).West = True

        Map(2, 1).Name = ""
        Map(2, 1).Description = ""
        Map(2, 1).North = False
        Map(2, 1).East = True
        Map(2, 1).South = True
        Map(2, 1).West = True

        Map(2, 2).Name = ""
        Map(2, 2).Description = ""
        Map(2, 2).North = True
        Map(2, 2).East = True
        Map(2, 2).South = True
        Map(2, 2).West = True

        Map(2, 3).Name = ""
        Map(2, 3).Description = ""
        Map(2, 3).North = True
        Map(2, 3).East = True
        Map(2, 3).South = True
        Map(2, 3).West = True

        Map(2, 4).Name = ""
        Map(2, 4).Description = ""
        Map(2, 4).North = True
        Map(2, 4).East = True
        Map(2, 4).South = True
        Map(2, 4).West = True

        Map(2, 5).Name = ""
        Map(2, 5).Description = ""
        Map(2, 5).North = True
        Map(2, 5).East = True
        Map(2, 5).South = True
        Map(2, 5).West = True

        Map(2, 6).Name = ""
        Map(2, 6).Description = ""
        Map(2, 6).North = True
        Map(2, 6).East = True
        Map(2, 6).South = True
        Map(2, 6).West = True

        Map(2, 7).Name = ""
        Map(2, 7).Description = ""
        Map(2, 7).North = True
        Map(2, 7).East = True
        Map(2, 7).South = True
        Map(2, 7).West = True

        Map(2, 8).Name = ""
        Map(2, 8).Description = ""
        Map(2, 8).North = True
        Map(2, 8).East = True
        Map(2, 8).South = True
        Map(2, 8).West = True

        Map(2, 9).Name = ""
        Map(2, 9).Description = ""
        Map(2, 9).North = True
        Map(2, 9).East = True
        Map(2, 9).South = True
        Map(2, 9).West = True

        Map(2, 10).Name = ""
        Map(2, 10).Description = ""
        Map(2, 10).North = True
        Map(2, 10).East = True
        Map(2, 10).South = False
        Map(2, 10).West = True

        'start of 3

        Map(3, 0).Name = ""
        Map(3, 0).Description = ""
        Map(3, 0).North = False
        Map(3, 0).East = True
        Map(3, 0).South = True
        Map(3, 0).West = True

        Map(3, 1).Name = ""
        Map(3, 1).Description = ""
        Map(3, 1).North = False
        Map(3, 1).East = True
        Map(3, 1).South = True
        Map(3, 1).West = True

        Map(3, 2).Name = ""
        Map(3, 2).Description = ""
        Map(3, 2).North = True
        Map(3, 2).East = True
        Map(3, 2).South = True
        Map(3, 2).West = True

        Map(3, 3).Name = ""
        Map(3, 3).Description = ""
        Map(3, 3).North = True
        Map(3, 3).East = True
        Map(3, 3).South = True
        Map(3, 3).West = True

        Map(3, 4).Name = ""
        Map(3, 4).Description = ""
        Map(3, 4).North = True
        Map(3, 4).East = True
        Map(3, 4).South = True
        Map(3, 4).West = True

        Map(3, 5).Name = ""
        Map(3, 5).Description = ""
        Map(3, 5).North = True
        Map(3, 5).East = True
        Map(3, 5).South = True
        Map(3, 5).West = True

        Map(3, 6).Name = ""
        Map(3, 6).Description = ""
        Map(3, 6).North = True
        Map(3, 6).East = True
        Map(3, 6).South = True
        Map(3, 6).West = True

        Map(3, 7).Name = ""
        Map(3, 7).Description = ""
        Map(3, 7).North = True
        Map(3, 7).East = True
        Map(3, 7).South = True
        Map(3, 7).West = True

        Map(3, 8).Name = ""
        Map(3, 8).Description = ""
        Map(3, 8).North = True
        Map(3, 8).East = True
        Map(3, 8).South = True
        Map(3, 8).West = True

        Map(3, 9).Name = ""
        Map(3, 9).Description = ""
        Map(3, 9).North = True
        Map(3, 9).East = True
        Map(3, 9).South = True
        Map(3, 9).West = True

        Map(3, 10).Name = ""
        Map(3, 10).Description = ""
        Map(3, 10).North = True
        Map(3, 10).East = True
        Map(3, 10).South = False
        Map(3, 10).West = True

        'start of 4

        Map(4, 0).Name = ""
        Map(4, 0).Description = ""
        Map(4, 0).North = False
        Map(4, 0).East = True
        Map(4, 0).South = True
        Map(4, 0).West = True

        Map(4, 1).Name = ""
        Map(4, 1).Description = ""
        Map(4, 1).North = False
        Map(4, 1).East = True
        Map(4, 1).South = True
        Map(4, 1).West = True

        Map(4, 2).Name = ""
        Map(4, 2).Description = ""
        Map(4, 2).North = True
        Map(4, 2).East = True
        Map(4, 2).South = True
        Map(4, 2).West = True

        Map(4, 3).Name = ""
        Map(4, 3).Description = ""
        Map(4, 3).North = True
        Map(4, 3).East = True
        Map(4, 3).South = True
        Map(4, 3).West = True

        Map(4, 4).Name = ""
        Map(4, 4).Description = ""
        Map(4, 4).North = True
        Map(4, 4).East = True
        Map(4, 4).South = True
        Map(4, 4).West = True

        Map(4, 5).Name = ""
        Map(4, 5).Description = ""
        Map(4, 5).North = True
        Map(4, 5).East = True
        Map(4, 5).South = True
        Map(4, 5).West = True

        Map(4, 6).Name = ""
        Map(4, 6).Description = ""
        Map(4, 6).North = True
        Map(4, 6).East = True
        Map(4, 6).South = True
        Map(4, 6).West = True

        Map(4, 7).Name = ""
        Map(4, 7).Description = ""
        Map(4, 7).North = True
        Map(4, 7).East = True
        Map(4, 7).South = True
        Map(4, 7).West = True

        Map(4, 8).Name = ""
        Map(4, 8).Description = ""
        Map(4, 8).North = True
        Map(4, 8).East = True
        Map(4, 8).South = True
        Map(4, 8).West = True

        Map(4, 9).Name = ""
        Map(4, 9).Description = ""
        Map(4, 9).North = True
        Map(4, 9).East = True
        Map(4, 9).South = True
        Map(4, 9).West = True

        Map(3, 10).Name = ""
        Map(3, 10).Description = ""
        Map(3, 10).North = True
        Map(3, 10).East = True
        Map(3, 10).South = False
        Map(3, 10).West = True

        'start of 5

        Map(5, 0).Name = ""
        Map(5, 0).Description = ""
        Map(5, 0).North = False
        Map(5, 0).East = True
        Map(5, 0).South = True
        Map(5, 0).West = True

        Map(5, 1).Name = ""
        Map(5, 1).Description = ""
        Map(5, 1).North = False
        Map(5, 1).East = True
        Map(5, 1).South = True
        Map(5, 1).West = True

        Map(5, 2).Name = ""
        Map(5, 2).Description = ""
        Map(5, 2).North = True
        Map(5, 2).East = True
        Map(5, 2).South = True
        Map(5, 2).West = True

        Map(5, 3).Name = ""
        Map(5, 3).Description = ""
        Map(5, 3).North = True
        Map(5, 3).East = True
        Map(5, 3).South = True
        Map(5, 3).West = True

        Map(5, 4).Name = ""
        Map(5, 4).Description = ""
        Map(5, 4).North = True
        Map(5, 4).East = True
        Map(5, 4).South = True
        Map(5, 4).West = True

        Map(5, 5).Name = ""
        Map(5, 5).Description = ""
        Map(5, 5).North = True
        Map(5, 5).East = True
        Map(5, 5).South = True
        Map(5, 5).West = True

        Map(5, 6).Name = ""
        Map(5, 6).Description = ""
        Map(5, 6).North = True
        Map(5, 6).East = True
        Map(5, 6).South = True
        Map(5, 6).West = True

        Map(5, 7).Name = ""
        Map(5, 7).Description = ""
        Map(5, 7).North = True
        Map(5, 7).East = True
        Map(5, 7).South = True
        Map(5, 7).West = True

        Map(5, 8).Name = ""
        Map(5, 8).Description = ""
        Map(5, 8).North = True
        Map(5, 8).East = True
        Map(5, 8).South = True
        Map(5, 8).West = True

        Map(5, 9).Name = ""
        Map(5, 9).Description = ""
        Map(5, 9).North = True
        Map(5, 9).East = True
        Map(5, 9).South = True
        Map(5, 9).West = True

        Map(5, 10).Name = ""
        Map(5, 10).Description = ""
        Map(5, 10).North = True
        Map(5, 10).East = True
        Map(5, 10).South = False
        Map(5, 10).West = True

        'start of 6

        Map(6, 0).Name = ""
        Map(6, 0).Description = ""
        Map(6, 0).North = False
        Map(6, 0).East = True
        Map(6, 0).South = True
        Map(6, 0).West = True

        Map(6, 1).Name = ""
        Map(6, 1).Description = ""
        Map(6, 1).North = False
        Map(6, 1).East = True
        Map(6, 1).South = True
        Map(6, 1).West = True

        Map(6, 2).Name = ""
        Map(6, 2).Description = ""
        Map(6, 2).North = True
        Map(6, 2).East = True
        Map(6, 2).South = True
        Map(6, 2).West = True

        Map(6, 3).Name = ""
        Map(6, 3).Description = ""
        Map(6, 3).North = True
        Map(6, 3).East = True
        Map(6, 3).South = True
        Map(6, 3).West = True

        Map(6, 4).Name = ""
        Map(6, 4).Description = ""
        Map(6, 4).North = True
        Map(6, 4).East = True
        Map(6, 4).South = True
        Map(6, 4).West = True

        Map(6, 5).Name = ""
        Map(6, 5).Description = ""
        Map(6, 5).North = True
        Map(6, 5).East = True
        Map(6, 5).South = True
        Map(6, 5).West = True

        Map(6, 6).Name = ""
        Map(6, 6).Description = ""
        Map(6, 6).North = True
        Map(6, 6).East = True
        Map(6, 6).South = True
        Map(6, 6).West = True

        Map(6, 7).Name = ""
        Map(6, 7).Description = ""
        Map(6, 7).North = True
        Map(6, 7).East = True
        Map(6, 7).South = True
        Map(6, 7).West = True

        Map(6, 8).Name = ""
        Map(6, 8).Description = ""
        Map(6, 8).North = True
        Map(6, 8).East = True
        Map(6, 8).South = True
        Map(6, 8).West = True

        Map(6, 9).Name = ""
        Map(6, 9).Description = ""
        Map(6, 9).North = True
        Map(6, 9).East = True
        Map(6, 9).South = True
        Map(6, 9).West = True

        Map(6, 10).Name = ""
        Map(6, 10).Description = ""
        Map(6, 10).North = True
        Map(6, 10).East = True
        Map(6, 10).South = False
        Map(6, 10).West = True

        'start of 7

        Map(7, 0).Name = ""
        Map(7, 0).Description = ""
        Map(7, 0).North = False
        Map(7, 0).East = True
        Map(7, 0).South = True
        Map(7, 0).West = True

        Map(7, 1).Name = ""
        Map(7, 1).Description = ""
        Map(7, 1).North = False
        Map(7, 1).East = True
        Map(7, 1).South = True
        Map(7, 1).West = True

        Map(7, 2).Name = ""
        Map(7, 2).Description = ""
        Map(7, 2).North = True
        Map(7, 2).East = True
        Map(7, 2).South = True
        Map(7, 2).West = True

        Map(7, 3).Name = ""
        Map(7, 3).Description = ""
        Map(7, 3).North = True
        Map(7, 3).East = True
        Map(7, 3).South = True
        Map(7, 3).West = True

        Map(7, 4).Name = ""
        Map(7, 4).Description = ""
        Map(7, 4).North = True
        Map(7, 4).East = True
        Map(7, 4).South = True
        Map(7, 4).West = True

        Map(7, 5).Name = ""
        Map(7, 5).Description = ""
        Map(7, 5).North = True
        Map(7, 5).East = True
        Map(7, 5).South = True
        Map(7, 5).West = True

        Map(7, 6).Name = ""
        Map(7, 6).Description = ""
        Map(7, 6).North = True
        Map(7, 6).East = True
        Map(7, 6).South = True
        Map(7, 6).West = True

        Map(7, 7).Name = ""
        Map(7, 7).Description = ""
        Map(7, 7).North = True
        Map(7, 7).East = True
        Map(7, 7).South = True
        Map(7, 7).West = True

        Map(7, 8).Name = ""
        Map(7, 8).Description = ""
        Map(7, 8).North = True
        Map(7, 8).East = True
        Map(7, 8).South = True
        Map(7, 8).West = True

        Map(7, 9).Name = ""
        Map(7, 9).Description = ""
        Map(7, 9).North = True
        Map(7, 9).East = True
        Map(7, 9).South = True
        Map(7, 9).West = True

        Map(7, 10).Name = ""
        Map(7, 10).Description = ""
        Map(7, 10).North = True
        Map(7, 10).East = True
        Map(7, 10).South = False
        Map(7, 10).West = True

        'start of 8

        Map(8, 0).Name = ""
        Map(8, 0).Description = ""
        Map(8, 0).North = False
        Map(8, 0).East = True
        Map(8, 0).South = True
        Map(8, 0).West = True

        Map(8, 1).Name = ""
        Map(8, 1).Description = ""
        Map(8, 1).North = False
        Map(8, 1).East = True
        Map(8, 1).South = True
        Map(8, 1).West = True

        Map(8, 2).Name = ""
        Map(8, 2).Description = ""
        Map(8, 2).North = True
        Map(8, 2).East = True
        Map(8, 2).South = True
        Map(8, 2).West = True

        Map(8, 3).Name = ""
        Map(8, 3).Description = ""
        Map(8, 3).North = True
        Map(8, 3).East = True
        Map(8, 3).South = True
        Map(8, 3).West = True

        Map(8, 4).Name = ""
        Map(8, 4).Description = ""
        Map(8, 4).North = True
        Map(8, 4).East = True
        Map(8, 4).South = True
        Map(8, 4).West = True

        Map(8, 5).Name = ""
        Map(8, 5).Description = ""
        Map(8, 5).North = True
        Map(8, 5).East = True
        Map(8, 5).South = True
        Map(8, 5).West = True

        Map(8, 6).Name = ""
        Map(8, 6).Description = ""
        Map(8, 6).North = True
        Map(8, 6).East = True
        Map(8, 6).South = True
        Map(8, 6).West = True

        Map(8, 7).Name = ""
        Map(8, 7).Description = ""
        Map(8, 7).North = True
        Map(8, 7).East = True
        Map(8, 7).South = True
        Map(8, 7).West = True

        Map(8, 8).Name = ""
        Map(8, 8).Description = ""
        Map(8, 8).North = True
        Map(8, 8).East = True
        Map(8, 8).South = True
        Map(8, 8).West = True

        Map(8, 9).Name = ""
        Map(8, 9).Description = ""
        Map(8, 9).North = True
        Map(8, 9).East = True
        Map(8, 9).South = True
        Map(8, 9).West = True

        Map(8, 10).Name = ""
        Map(8, 10).Description = ""
        Map(8, 10).North = True
        Map(8, 10).East = True
        Map(8, 10).South = False
        Map(8, 10).West = True

        'start of 9

        Map(9, 0).Name = ""
        Map(9, 0).Description = ""
        Map(9, 0).North = False
        Map(9, 0).East = True
        Map(9, 0).South = True
        Map(9, 0).West = True

        Map(9, 1).Name = ""
        Map(9, 1).Description = ""
        Map(9, 1).North = False
        Map(9, 1).East = True
        Map(9, 1).South = True
        Map(9, 1).West = True

        Map(9, 2).Name = ""
        Map(9, 2).Description = ""
        Map(9, 2).North = True
        Map(9, 2).East = True
        Map(9, 2).South = True
        Map(9, 2).West = True

        Map(9, 3).Name = ""
        Map(9, 3).Description = ""
        Map(9, 3).North = True
        Map(9, 3).East = True
        Map(9, 3).South = True
        Map(9, 3).West = True

        Map(9, 4).Name = ""
        Map(9, 4).Description = ""
        Map(9, 4).North = True
        Map(9, 4).East = True
        Map(9, 4).South = True
        Map(9, 4).West = True

        Map(9, 5).Name = ""
        Map(9, 5).Description = ""
        Map(9, 5).North = True
        Map(9, 5).East = True
        Map(9, 5).South = True
        Map(9, 5).West = True

        Map(9, 6).Name = ""
        Map(9, 6).Description = ""
        Map(9, 6).North = True
        Map(9, 6).East = True
        Map(9, 6).South = True
        Map(9, 6).West = True

        Map(9, 7).Name = ""
        Map(9, 7).Description = ""
        Map(9, 7).North = True
        Map(9, 7).East = True
        Map(9, 7).South = True
        Map(9, 7).West = True

        Map(9, 8).Name = ""
        Map(9, 8).Description = ""
        Map(9, 8).North = True
        Map(9, 8).East = True
        Map(9, 8).South = True
        Map(9, 8).West = True

        Map(9, 9).Name = ""
        Map(9, 9).Description = ""
        Map(9, 9).North = True
        Map(9, 9).East = True
        Map(9, 9).South = True
        Map(9, 9).West = True

        Map(9, 10).Name = ""
        Map(9, 10).Description = ""
        Map(9, 10).North = True
        Map(9, 10).East = True
        Map(9, 10).South = False
        Map(9, 10).West = True

        'start of 10

        Map(10, 0).Name = ""
        Map(10, 0).Description = ""
        Map(10, 0).North = False
        Map(10, 0).East = False
        Map(10, 0).South = True
        Map(10, 0).West = True

        Map(10, 1).Name = ""
        Map(10, 1).Description = ""
        Map(10, 1).North = False
        Map(10, 1).East = False
        Map(10, 1).South = True
        Map(10, 1).West = True

        Map(10, 2).Name = ""
        Map(10, 2).Description = ""
        Map(10, 2).North = True
        Map(10, 2).East = False
        Map(10, 2).South = True
        Map(10, 2).West = True

        Map(10, 3).Name = ""
        Map(10, 3).Description = ""
        Map(10, 3).North = True
        Map(10, 3).East = False
        Map(10, 3).South = True
        Map(10, 3).West = True

        Map(10, 4).Name = ""
        Map(10, 4).Description = ""
        Map(10, 4).North = True
        Map(10, 4).East = False
        Map(10, 4).South = True
        Map(10, 4).West = True

        Map(10, 5).Name = ""
        Map(10, 5).Description = ""
        Map(10, 5).North = True
        Map(10, 5).East = False
        Map(10, 5).South = True
        Map(10, 5).West = True

        Map(10, 6).Name = ""
        Map(10, 6).Description = ""
        Map(10, 6).North = True
        Map(10, 6).East = False
        Map(10, 6).South = True
        Map(10, 6).West = True

        Map(10, 7).Name = ""
        Map(10, 7).Description = ""
        Map(10, 7).North = True
        Map(10, 7).East = False
        Map(10, 7).South = True
        Map(10, 7).West = True

        Map(10, 8).Name = ""
        Map(10, 8).Description = ""
        Map(10, 8).North = True
        Map(10, 8).East = False
        Map(10, 8).South = True
        Map(10, 8).West = True

        Map(10, 9).Name = ""
        Map(10, 9).Description = ""
        Map(10, 9).North = True
        Map(10, 9).East = False
        Map(10, 9).South = True
        Map(10, 9).West = True

        Map(10, 10).Name = ""
        Map(10, 10).Description = ""
        Map(10, 10).North = True
        Map(10, 10).East = False
        Map(10, 10).South = False
        Map(10, 10).West = True




        If Name.pclass = "warrior" Then
            Inv(0).item_name = "War axe"
            Inv(0).item_desc = "A large, dulled, silver headed axe with a smooth leather wrapped wooden handle"
            Inv(0).effect = "standard damage with slashing damage effect"
            Inv(0).X_loc = -1
            Inv(0).Y_loc = -1
            Inv(0).item_number = 1

            Inv(1).item_name = "ID"
            Inv(1).item_desc = vbCrLf & "It Reads: " & vbCrLf & "Name: " & Name.Pname & vbCrLf & "Age: 27" & vbCrLf & "Bodily status: Dead" & vbCrLf & "Occupation: Unemployed " & vbCrLf & "Previous occupations: " & Name.pclass
            Inv(1).effect = ""
            Inv(1).X_loc = 0
            Inv(1).Y_loc = 1
            Inv(1).item_number = 0

            numofItems = 2
        ElseIf Name.pclass = "mage" Then
            Inv(0).item_name = "Mage staff"
            Inv(0).item_desc = "A long, rough, tree branch like staff which bearly manages to focus the mystical energy within you."
            Inv(0).effect = "tbt"
            Inv(0).X_loc = -1
            Inv(0).Y_loc = -1
            Inv(0).item_number = 2

            Inv(1).item_name = "ID"
            Inv(1).item_desc = vbCrLf & "It Reads: " & vbCrLf & "Name: " & Name.Pname & vbCrLf & "Age: 27" & vbCrLf & "Bodily status: Dead" & vbCrLf & "Occupation: Unemployed " & vbCrLf & "Previous occupations: " & Name.pclass
            Inv(1).effect = ""
            Inv(1).X_loc = 0
            Inv(1).Y_loc = 1
            Inv(1).item_number = 0

            numofItems = 2
        ElseIf Name.pclass = "rogue" Then
            Inv(0).item_name = "worn blades"
            Inv(0).item_desc = "two short blades, slightly dulled but still mininbst"
            Inv(0).effect = "slashing damage"
            Inv(0).X_loc = -1
            Inv(0).Y_loc = -1
            Inv(0).item_number = 3


            Inv(1).item_name = "Old short bow"
            Inv(1).item_desc = "An ancient short bow that does minimal damage due to how frail it is"
            Inv(1).effect = "peircing damage"
            Inv(1).X_loc = -1
            Inv(1).Y_loc = -1
            Inv(1).item_number = 4

            Inv(2).item_name = "ID"
            Inv(2).item_desc = vbCrLf & "It Reads: " & vbCrLf & "Name: " & Name.Pname & vbCrLf & "Age: 27" & vbCrLf & "Bodily status: Dead" & vbCrLf & "Occupation: Unemployed " & vbCrLf & "Previous occupations: " & Name.pclass
            Inv(2).effect = ""
            Inv(2).X_loc = 0
            Inv(2).Y_loc = 1
            Inv(2).item_number = 0

            numofItems = 3
        End If


        Inv(numofItems - 1).item_name = ""
        Inv(numofItems - 1).item_desc = ""
        Inv(numofItems - 1).effect = ""
        Inv(numofItems - 1).X_loc = -2
        Inv(numofItems - 1).Y_loc = -2


        Inv(numofItems).item_name = ""
        Inv(numofItems).item_desc = ""
        Inv(numofItems).effect = ""
        Inv(numofItems).X_loc = -2
        Inv(numofItems).Y_loc = -2


        Inv(numofItems + 1).item_name = ""
        Inv(numofItems + 1).item_desc = ""
        Inv(numofItems + 1).effect = ""
        Inv(numofItems + 1).X_loc = -2
        Inv(numofItems + 1).Y_loc = -2

        'If Name.pclass = "warrior" Then
        '    Inv(1).X_loc = -1
        '    Inv(1).Y_loc = -1
        '
        'ElseIf Name.pclass = "mage" Then
        '    Inv(2).X_loc = -1
        '    Inv(2).Y_loc = -1
        '    Inv(2).item_number = 2
        'ElseIf Name.pclass = "rogue" Then
        '    Inv(3).X_loc = -1
        '    Inv(3).Y_loc = -1
        '    Inv(4).X_loc = -1
        '    Inv(4).Y_loc = -1
        '    Inv(3).item_number = 2
        '    Inv(4).item_number = 3
        'End If
        Read()
        Inp()
    End Sub

End Module

