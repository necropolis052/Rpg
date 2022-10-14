Imports System

Module Program

    Dim Inventory_items() As String = {"1) Slot 1: " & "sword", "2)Slot 2: " & "sheild", "Key items:"}
    Sub main()
        Inventory()
    End Sub
    Sub Inventory()
        Dim inv_num As Integer
        Dim Inv_action As String
        inv_num = 0
        Console.WriteLine("Inventory: ")
        For x = 0 To Inventory_items.Length - 1

            Console.WriteLine(Inventory_items(inv_num))
            inv_num = inv_num + 1
        Next
        Console.WriteLine("Input a number to inspect or B to close inventory: ")
        Inv_action = Console.ReadLine
        If Inv_action =  Then

        End If

    End Sub
End Module
