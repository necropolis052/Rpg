
Imports System
Imports System.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Math
module game
dim bar as string = "+----------------------------------------------------------------------------------------------------------------------------------------------------------+" 
dim x as Integer
dim name as string
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
        Console.WriteLine("                              Welcome to my text based rpg! ")
        Console.ForegroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Red

        Console.WriteLine("      `-.__   _,-.   )       _,.-'")
        Console.WriteLine("           `""     G..m-""^m`m'")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        Console.WriteLine("                                                               Would you like to start a game? y/n ")
        for x = 0 to 15
            console.writeline()
        next
        console.writeline(bar)
        console.writeline()
        If Console.ReadLine = "y" Then
            Console.Clear()
            console.writeline("What is your name brave adventurer?: ")
            name = console.ReadLine()
            start()
        Else
            End
        End If

    End Sub
    Sub start()
        Dim health As Integer = 100 
        dim path as string
        dim choice as string
        

            console.writeline()
            Console.WriteLine(bar)
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("                                        " & name & ", You come across a forest. The entrance to the forest has 2 paths ")
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
                console.clear()
                console.writeline(bar)
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine("  Once you've walked far enough into the brambles, a bright light appears along the path and as it dissapates a pair of wings appear floating in the air.")
                Console.ForegroundColor = ConsoleColor.Red
                console.WriteLine()
                console.writeline("                                                                           The Angel")
                console.writeline()
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine("   ""Pleadge you alleigance to my master and I shall grant you holy guidance and the power to smite those who block your path along this grand adventure."" ")
                Console.ForegroundColor = ConsoleColor.White
                console.writeline(bar)
                for x = 0 to 5
                    console.writeline()
                next
                console.writeline("                                                .                                                            ,")
                console.writeline("                                                |`.                                                        ,'|")
                console.writeline("                                                \_`-._                                                  _,-'_/")
                console.writeline("                                               ./ \-._`-._                                          _,-'_,-/ \,")
                console.writeline("                                               \._/._ `._>`-.__                                __,-'<_,' _,\_,/")
                console.writeline("                                               /_ \_.`-._\_-._ `--__                      __--' _,-_/_,-',_/ _\")
                console.writeline("                                                /._`\_./ _`_./`.-._ `-.                ,-' _,-,'\,_'_ \,_/'_,\")
                console.writeline("                                                 \._`/ _/ _`_./  _/`\_ `.            ,' _/'\_  \,_'_ \_ \'_,/")
                console.writeline("                                                  /._`/ _/ _`_./` _/ `\_ `\_      _/' _/' \_ '\,_'_ \_ \'_,\")
                console.writeline("                                                   \._`/ _/ _`_./` __/  >.  `-.,-'  ,<  \__ '\,_'_ \_ \'_,/")
                console.writeline("                                                     /_`/._/._`_./` __.`.-\_.-`'-._/-,',__ '\,_'_,\_,\'_\")
                console.writeline("                                                           `\._`_./`\._/_/'        `\_\_,/'\,_'_,/'")
                for x = 0 to 9
                    console.writeline()
                next
                console.writeline(bar)
                console.writeline(" Health " & health & "/100 Press y or n to accept or decline the Angels offer: ")
                console.writeline(bar)
                console.writeline()
                choice = console.ReadLine
            else
                console.clear()
                console.writeline(bar)
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine("  Once you've walked far enough into the brambles, a bright light appears along the path and as it dissapates a devil appears floating in the air.")
                Console.ForegroundColor = ConsoleColor.Red
                console.WriteLine()
                console.writeline("                                                                           The Daemon")
                console.writeline()
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine("  ""Pleadge you alleigance to my master and I shall grant you profane guidance and the power to smite those who block your path along this grand adventure."" ")
                Console.ForegroundColor = ConsoleColor.White
                console.writeline(bar)
                for x = 0 to 5
                    console.writeline()
                next
                console.writeline("                                                                              ,-.")
                console.writeline("                                                         ___,---.__          /'|`\          __,---,___")
                console.writeline("                                                      ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.")
                console.writeline("                                                    ,'        |           ~'\     /`~           |        `.")
                console.writeline("                                                   /      ___//              `. ,'          ,  , \___      \")
                console.writeline("                                                  |    ,-'   `-.__   _         |        ,    __,-'   `-.    |")
                console.writeline("                                                  |   /          /\_  `   .    |    ,      _/\          \   |")
                console.writeline("                                                  \  |           \ \`-.___ \   |   / ___,-'/ /           |  /")
                console.writeline("                                                   \  \           | `._   `\\  |  //'   _,' |           /  /")
                console.writeline("                                                    `-.\         /'  _ `---'' , . ``---' _  `\         /,-'")
                console.writeline("                                                       ``       /     \    ,='/ \`=.    /     \       ''")
                console.writeline("                                                               |__   /|\_,--.,-.--,--._/|\   __|")
                console.writeline("                                                               /  `./  \\`\ |  |  | /,//' \,'  \")
                console.writeline("                                                              /   /     ||--+--|--+-/-|     \   \")
                console.writeline("                                                             |   |     /'\_\_\ | /_/_/`\     |   |")
                console.writeline("                                                              \   \__, \_     `~'     _/ .__/   /")
                console.writeline("                                                               `-._,-'   `-._______,-'   `-._,-'")
                for x = 0 to 5
                    console.writeline()
                next
                
                console.writeline(bar)
                console.writeline(" Health " & health & "/100 Press y or n to accept or decline the Daemons offer: ")
                console.writeline(bar)
                console.writeline()
                choice = console.ReadLine
            end if

    End Sub
    
end module 
