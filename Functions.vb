Imports rpg.game
Imports System.IO

Module Functions
    Function title_screen_options(x As String) As String
        Dim opt As String
        opt = x
        If opt.ToLower.Contains("play") Then
            Console.Clear()
            Read()
        ElseIf opt.ToLower.Contains("new game") Then
            Try
                File.Delete("U:\computer science\Save.txt")

                New_game()
            Catch ex As Exception
                New_game()
            End Try

        ElseIf opt.ToLower.Contains("quit") Then

            End

        ElseIf opt.ToLower.Contains("help") Then
            Help_menu()

        End If
    End Function
    Function print_location(a As Integer, b As Integer) As String
        Console.ForegroundColor = ConsoleColor.Yellow
        For x = 0 To (Map(a, b).Name.Length + 3)
            Console.Write("#")
        Next
        Console.WriteLine()
        Console.WriteLine("# " & Map(a, b).Name & " #")
        For x = 0 To (Map(a, b).Name.Length + 3)
            Console.Write("#")
        Next
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine()
        If Map(a, b).Description.Length > 1 Then
            Console.ForegroundColor = ConsoleColor.Blue
            Console.WriteLine("Description: " & Map(a, b).Description) 'new----------------------------
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Directions: " & Map(a, b).direction)
            Console.ForegroundColor = ConsoleColor.White

        End If

        For y = 0 To 7
            If Map(a, b).items(y).Length > 1 Then
                For x = 0 To 7
                    If Map(playerx, playery).items(x) = Inv(x).item_name Then
                        If Inv(x).exists = False Then
                            Console.WriteLine("The items in " & Map(a, b).Name & " are as follows: " & Map(a, b).items(x))
                        End If

                    End If
                Next

            End If
        Next



    End Function
    Function commands(command As String) As String
        command = command.ToLower
        Dim y As Integer
        If command.Contains("north") Or command.Contains("up") Then
            If Map(playerx, playery).North = True Then
                playery = playery - 1
                Console.Clear()
                'loops back to input function to catch another command
                Inp()
            Else
                Console.Clear()
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.WriteLine()

                Inp()

            End If
        ElseIf command.Contains("east") Or command.Contains("right") Then
            If Map(playerx, playery).East = True Then
                playerx = playerx + 1
                Console.Clear()
                Inp()
            Else
                Console.Clear()
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.WriteLine()

                Inp()

            End If

        ElseIf command.Contains("south") Or command.Contains("down") Then
            If Map(playerx, playery).South = True Then
                playery = playery + 1
                Console.Clear()
                Inp()
            Else
                Console.Clear()
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.WriteLine()

                Inp()

            End If
        ElseIf command.Contains("west") Or command.Contains("left") Then
            If Map(playerx, playery).West = True Then
                playerx = playerx - 1
                Console.Clear()
                Inp()
            Else
                Console.Clear()
                Console.WriteLine("You find yourself unable to walk in that directon as there's no exits. ")
                Console.WriteLine()
                Console.WriteLine("Please try entering your command again")
                Console.WriteLine()

                Inp()

            End If
        ElseIf command.Contains("inventory") Or command.Contains("inv") Then
            Bag()
        ElseIf command.Contains("block") Or command.Contains("sheild") Or command.Contains("stop") Then

        ElseIf command.Contains("kill") Or command.Contains("attack") Then

        ElseIf command.Contains("grab") Or command.Contains("get") Then
            For y = 0 To 7
                If command.Contains(Map(playerx, playery).items(y).ToLower) Then
                    For x = 0 To 7
                        If command.Contains(Inv(x).item_name.ToLower) Then
                            If Inv(x).exists = False Then
                                Inv(x).exists = True
                                Map(playerx, playery).items.Remove(x)
                                Console.WriteLine("You picked up the " & Inv(x).item_name & " and added it to your backpack")
                            ElseIf Inv(x).exists = True Then
                                Console.WriteLine("That item doesn't exist here or it's in your backpack")
                            End If

                            Inp()
                        End If
                    Next
                ElseIf command.Contains(Map(playerx, playery).items(y).ToLower) = False Then

                    Console.WriteLine("That item doesn't exist here")
                    Inp()
                End If
            Next
        ElseIf command.Contains("quit") Then
            Console.WriteLine("are you sure that you want to quit the game y/n")
            If Console.ReadLine.ToLower.Contains("y") Or Console.ReadLine.ToLower.Contains("ok") Then
                ended = True
                Save()
            Else
                Console.WriteLine("ok")
                Console.Clear()
                Inp()
            End If
            'ElseIf command.Contains("help") Then
            'help_menu()
            'end if
        ElseIf command.Contains("save") Then
            Save()

        ElseIf command.Contains("read") Then
            Read()
        End If


    End Function
End Module
