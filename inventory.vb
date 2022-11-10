Imports System

Module Program

    Dim Inventory_items() As String = {"1) Slot 1: " & "sword", "2)Slot 2: " & "sheild", "Key items:"}
    Sub main()
        Inventory()
    End Sub
    Sub Inventory()
        Dim inv_num As Integer
        Dim Inv_action As String
        Dim item_chosen As Boolean
        Dim inv_end As Boolean
        item_chosen = False
        inv_end = False
        Do
            inv_num = 0
            Console.WriteLine("Inventory: ")
            For x = 0 To Inventory_items.Length - 1

                Console.WriteLine(Inventory_items(inv_num))
                inv_num = inv_num + 1
            Next
            Console.WriteLine("Input a number to inspect or B to close inventory: ") ' gives the player choice to either close inventory or access item options
            Inv_action = Console.ReadLine()
            Inv_action = CStr(Inv_action)
            If Inv_action = "1" Or Inv_action = "2" Or Inv_action = "3" Or Inv_action = "4" Or Inv_action = "5" Or Inv_action = "6" Then
                item_chosen = True
            End If

            If Inv_action = "b" Or Inv_action = "B" Then
                inv_end = True
            End If ' if the player chooses to close inventory it closes inv

        Loop Until inv_end = True
        Console.WriteLine("cheese")
    End Sub
End Module
