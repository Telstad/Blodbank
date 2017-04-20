Imports System.Text
Imports MySql.Data.MySqlClient
Public Class Legesjekk
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        Dim tilkobling As New MySqlConnection(
        "Server=mysql.stud.iie.ntnu.no;" _
       & "Database=g_oops_04;" _
       & "Uid=g_oops_04;" _
       & "Pwd=W1TzS2W4;")


        Dim If_nr = TextBox1.Text

        Try
            tilkobling.Open()
            MsgBox("Alt gikk greit med å koble til databasen")
            'Lager sentrale objekter

            Dim sql As New MySqlCommand("SELECT * FROM legeSjekk WHERE f_nr = @If_nr ", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@If_nr", If_nr)
            'Objektet "da" utfører spørringen og legger resultatet i "interntabell"
            da.SelectCommand = sql
            da.Fill(interntabell)


            'Har ikke lenger bruk for å være tilkoblet til databasen
            tilkobling.Close()


            'En tabell har mange rader. DataRow-objektet kan lagre 1 rad om gangen
            Dim rad As DataRow
            Dim fornavn, etternavn, adresse, tlf, email, f_nr As String 'hjelpevariabler


            'Fyller listeboksen med ønsket informasjon
            For Each rad In interntabell.Rows
                fornavn = rad("fornavn")
                etternavn = rad("etternavn")
                adresse = rad("adresse")
                tlf = rad("tlf")
                email = rad("email")
                f_nr = rad("f_nr")
                ListBox1.Items.Add(fornavn)
                ListBox1.Items.Add(etternavn)
                ListBox1.Items.Add(adresse)
                ListBox1.Items.Add(tlf)
                ListBox1.Items.Add(email)
                ListBox1.Items.Add(f_nr)
            Next rad

        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try

        'Form1.Hide()
    End Sub

    Private Sub Godkjenn_Click(sender As Object, e As EventArgs) Handles Godkjenn.Click
        'oppkobling mot databasen
        Dim tilkobling As New MySqlConnection(
            "Server=mysql.stud.iie.ntnu.no;" _
           & "Database=g_oops_04;" _
           & "Uid=g_oops_04;" _
           & "Pwd=W1TzS2W4;")
        Dim If_nr = TextBox1.Text
        'lager ett autogenerert passord
        Dim rndnumber As Random
        Dim number As Integer
        Dim passord As String
        rndnumber = New Random
        number = rndnumber.Next(1, 80000)
        passord = number.ToString


        Try
            tilkobling.Open()
            MsgBox("Donoren vil få en eMail med brukernavn/passord")
            'Lager sentrale objekter

            Dim fornavn, etternavn, email, tlf, f_nr, adresse, brukernavn, rolleId, blodtype As String
            fornavn = ListBox1.Items(0).ToString
            etternavn = ListBox1.Items(1).ToString
            adresse = ListBox1.Items(2).ToString
            tlf = ListBox1.Items(3).ToString
            email = ListBox1.Items(4).ToString
            f_nr = ListBox1.Items(5).ToString
            brukernavn = ListBox1.Items(4).ToString
            rolleId = 1
            blodtype = TextBox2.Text
            MsgBox("'simulerer email til donor'Din blodtype er:" & blodtype & "  Ditt brukernavn er: " & email & " og ditt passord er: " & passord) 'TODO skal byttet ut med kode for og sende mail.


            'lagrer kontaktinfo om Bruker/Donor opp mot databasen
            Dim sql As New MySqlCommand("INSERT INTO BrukerDonor (fornavn, etternavn, email, tlf, f_nr, adresse, brukernavn, passord, rolleId, blodtype) VALUES (@fornavn, @etternavn, @email, @tlf, @f_nr, @adresse, @brukernavn, @passord, @rolleId, @blodtype)", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@fornavn", fornavn)
            sql.Parameters.AddWithValue("@etternavn", etternavn)
            sql.Parameters.AddWithValue("@email", email)
            sql.Parameters.AddWithValue("@tlf", tlf)
            sql.Parameters.AddWithValue("@f_nr", f_nr)
            sql.Parameters.AddWithValue("@adresse", adresse)
            sql.Parameters.AddWithValue("@brukernavn", brukernavn)
            sql.Parameters.AddWithValue("@passord", passord)
            sql.Parameters.AddWithValue("@rolleId", rolleId)
            sql.Parameters.AddWithValue("@blodtype", blodtype)
            sql.ExecuteNonQuery()



            'Denne koden sletter brukere i kø for og komme på legesjekk når de blir godkjente og får en bruker.
            Dim sql2 As New MySqlCommand("DELETE FROM legeSjekk WHERE f_nr = @If_nr ", tilkobling)
            Dim da2 As New MySqlDataAdapter
            Dim interntabell2 As New DataTable
            sql2.Parameters.AddWithValue("@If_nr", If_nr)
            sql2.ExecuteNonQuery()

            tilkobling.Close() ' stenger tilkoblingen til databasen
            'sjekker for feilmelding
        Catch feilmelding As MySqlException
            MsgBox("Feil ved tilkobling til databasen: " &
            feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try

    End Sub

End Class
