Module Program

    Dim Inventory_items() As String = {"1) Slot 1: " & "sword", "2)Slot 2: " & "sheild", "Key items:"}
    Sub main()
        backpack()
    End Sub
    Function bag() As String
        For x = 0 To 7
            Console.WriteLine(inv(x).item_name)
        Next
    End Function
    Dim inv(7) As inventory
    Dim inv_num As Integer
    Dim Inv_action As String
    Dim item_chosen As Boolean
    Dim inv_end As Boolean
    Structure inventory
        Dim item_name As String
        Dim item_desc As String
        Dim effect As String
        Dim exists As Boolean
    End Structure
    Sub backpack()

        item_chosen = False
        inv_end = False
        '  (x, y)
        inv(0).item_name = "Empty slot 1"
        inv(0).item_desc = ""
        inv(0).effect = ""
        inv(0).exists = False

        inv(1).item_name = "War axe"
        inv(1).item_desc = "A large, dulled, silver headed axe with a smooth leather wrapped wooden handle"
        inv(1).effect = "standard damage with slashing damage effect"
        inv(1).exists = False

        inv(2).item_name = "Mage staff"
        inv(2).item_desc = "A long, rough, tree branch like staff which bearly manages to focus the mystical energy within you."
        inv(2).effect = "tbt"
        inv(2).exists = False

        inv(3).item_name = "worn blades"
        inv(3).item_desc = "two short blades, slightly dulled but still usable"
        inv(3).effect = "slashing damage"
        inv(3).exists = False

        inv(4).item_name = "Old short bow"
        inv(4).item_desc = "An ancient short bow that does minimal damage due to how frail it is"
        inv(4).effect = "peircing damage"
        inv(4).exists = False

        inv(5).item_name = ""
        inv(5).item_desc = ""
        inv(5).effect = ""
        inv(5).exists = False

        inv(6).item_name = ""
        inv(6).item_desc = ""
        inv(6).effect = ""
        inv(6).exists = False

        inv(7).item_name = ""
        inv(7).item_desc = ""
        inv(7).effect = ""
        inv(7).exists = False

        bag()



        'Do
        '    inv_num = 0
        '    Console.WriteLine("Inventory: ")
        '    For x = 0 To Inventory_items.Length - 1
        '
        '        Console.WriteLine(Inventory_items(inv_num))
        '        inv_num = inv_num + 1
        '    Next
        '    Console.WriteLine("Input a number to inspect or B to close inventory: ") ' gives the player choice to either close inventory or access item options
        '    Inv_action = Console.ReadLine()
        '    Inv_action = CStr(Inv_action)
        '    If Inv_action = "1" Or Inv_action = "2" Or Inv_action = "3" Or Inv_action = "4" Or Inv_action = "5" Or Inv_action = "6" Then
        '        item_chosen = True
        '    End If
        '
        '    If Inv_action = "b" Or Inv_action = "B" Then
        '        inv_end = True
        '    End If ' if the player chooses to close inventory it closes inv
        '
        'Loop Until inv_end = True
        'Console.WriteLine("cheese")
    End Sub
End Module
