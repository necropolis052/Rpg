
Imports System
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Math
Structure location
    Dim Name As String
    Dim Description As String
    Dim North, East, South, West As Boolean
    Dim items As String
    Dim Npcs As String
End Structure
Module game
    Dim Map(10, 10) As location
    Dim bar As String = "+----------------------------------------------------------------------------------------------------------------------------------------------------------+"
    Dim x As Integer
    Dim name As String
    Sub Main()
        ''Console.WindowWidth = Console.LargestWindowWidth
        ''Console.WindowHeight = Console.LargestWindowHeight
        Console.WindowWidth = 156
        Console.WindowHeight = 40
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
        Console.WriteLine("                                                               Would you like to start a game? y/n ")
        For x = 0 To 15
            Console.WriteLine()
        Next
        Console.WriteLine(bar)
        Console.WriteLine()
        If Console.ReadLine = "y" Then
            Console.Clear()
            Console.WriteLine("What is your name brave adventurer?: ")
            name = Console.ReadLine()
            start()
        Else
            End
        End If


    End Sub
    Sub start()
        Dim health As Integer = 100
        Map(0, 0).Name = "Forest"
        Map(0, 0).Description = ""
        Map(0, 0).North = True
        Map(0, 0).East = True
        Map(0, 0).South = True
        Map(0, 0).West = True
        Map(0, 0).
        Map(0, 0)
        Map(0, 0)
        Map(0, 0)
        Map(0, 0)


    End Sub
    Sub boss()
        Dim path As String
        Dim choice As String


        Console.WriteLine()
        Console.WriteLine(bar)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("                                        " & name & ", You come across a forest. The entrance to the forest has 2 paths ")
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
