Imports MySql.Data.MySqlClient
Public Class BestillingAvBlod


    Private Sub BestillingAvBlod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")


        Try
            tilkobling.Open()
            MsgBox("Alt gikk greit med å koble til databasen")
            'Lager sentrale objekter

            Dim sql As New MySqlCommand("Select blodtype, type, COUNT(*) antall FROM Blod_lab GROUP BY blodtype, type", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            da.SelectCommand = sql
            da.Fill(interntabell)
            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen
            Dim rad As DataRow
            Dim blodtype, type As String
            Dim antall As Integer 'hjelpevariabler

            'Fyller listeboksen med ønsket informasjon
            For Each rad In interntabell.Rows
                blodtype = rad("blodtype")
                type = rad("type")
                antall = rad("antall")

                ListBox2.Items.Add(blodtype & ", " & type & ", " & antall)
            Next rad

        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        End Try



    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim antall_poser As Integer = ComboBox1.SelectedItem
        Dim blodtype As String = ComboBox2.SelectedItem
        Dim produkt As String = ComboBox3.SelectedItem

        ListBox1.Items.Add("ant poser: " & antall_poser & ", blodtype: " & blodtype & ", type produkt " & produkt)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("din bestilling er mottatt")
        'slette poser med blodprodukter fra Blod_lab
        'personene som har blodposer som blir sletta få en sms om at de hav vært med på og redde ett liv. 
        MsgBox("donorene til det brukte blodet vil få sms om at de har vært med på og redde ett liv.")
        Me.Close()
    End Sub
End Class