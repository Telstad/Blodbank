Imports MySql.Data.MySqlClient
Public Class LeggTilHelsepersonell
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tilkobling As New MySqlConnection(
           "Server=mysql.stud.iie.ntnu.no;" _
          & "Database=g_oops_04;" _
          & "Uid=g_oops_04;" _
          & "Pwd=W1TzS2W4;")

        Try
            tilkobling.Open()
            MsgBox("Ansatt er lagt til.")
            'Lager sentrale objekter

            Dim fornavn, etternavn, email, tlf, f_nr, adresse, rolleid, brukernavn As String 'setter variablene
            fornavn = TextBox1.Text
            etternavn = TextBox2.Text
            email = TextBox3.Text
            tlf = TextBox4.Text
            f_nr = TextBox5.Text
            adresse = TextBox6.Text
            rolleid = 2
            brukernavn = TextBox3.Text


            'lager ett random passord.
            Dim rndnumber As Random
            Dim number As Integer
            Dim passord As String
            rndnumber = New Random
            number = rndnumber.Next(1, 80000)
            passord = number.ToString

            'lagrer kontaktinfo om donor opp mot databasen
            Dim sql As New MySqlCommand("INSERT INTO BrukerDonor (fornavn, etternavn, email, tlf, f_nr, adresse, rolleid, brukernavn, passord) VALUES (@fornavn, @etternavn, @email, @tlf, @f_nr, @adresse, @rolleid, @brukernavn, @passord)", tilkobling)
            Dim da As New MySqlDataAdapter
            Dim interntabell As New DataTable

            sql.Parameters.AddWithValue("@fornavn", fornavn)
            sql.Parameters.AddWithValue("@etternavn", etternavn)
            sql.Parameters.AddWithValue("@email", email)
            sql.Parameters.AddWithValue("@tlf", tlf)
            sql.Parameters.AddWithValue("@f_nr", f_nr)
            sql.Parameters.AddWithValue("@adresse", adresse)
            sql.Parameters.AddWithValue("@rolleid", rolleid)
            sql.Parameters.AddWithValue("@brukernavn", brukernavn)
            sql.Parameters.AddWithValue("@passord", passord)
            sql.ExecuteNonQuery()
            MsgBox("'simulerer email til helsepersonell " & "  Ditt brukernavn er: " & brukernavn & " og ditt passord er: " & passord & " skriv dette ned") 'TODO skal byttet ut med kode for og sende mail.
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