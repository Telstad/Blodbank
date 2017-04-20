Imports MySql.Data.MySqlClient 'Importerer MySQL-tillegg.

Public Class Form1
    Private tilkobling As MySqlConnection 'Lukket variabel som defineres som en ny SQL-tilkobling.

    'Ved lukking av skjemaet. 
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        tilkobling.Close() 'Lukk tilkoblingen.
        tilkobling.Dispose() 'Kvitte seg med ubehandlede ressurser. 
    End Sub

    'Ved innlasting av skjemaet. 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Definerer tilkobling.
        '...Angir servernavn, databasenavn, brukernavn og passord for SQL tilkoblingen.
        tilkobling = New MySqlConnection("Server=mysql.stud.iie.ntnu.no;" _
          & "Database=g_oops_04;" _
          & "Uid=g_oops_04;" _
           & "Pwd=W1TzS2W4;")

        tilkobling.Open() 'Åpner tilkoblingen.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim brukernavn = TextBox1.Text 'Angir hvilket felt som er for brukernavn.
        Dim passord = TextBox2.Text 'Angir hvilket felt osm er for passord.
        Dim rolleId = " " 'rolleId går fra 1 til 3 og anngir om brukeren er en administrator, helsepersonell eller donor.
        Dim f_nr = " " 'f_nr til bruker, mest nødvendig fra donor, men blir også henten fra de andre brukerne.
        Dim fornavn = " " ' henter fornavn ved innlogging så brukeren han ha en visual validering av at det er faktisk de som er logget på

        Try
            'SQL-spørring som ser etter en brukeren i databasen.
            Dim sqlSporring = "select * from BrukerDonor where brukernavn=@brukernavn" & " and passord=@passord"

            'Utfører spørringen mot databasen.
            Dim sql As New MySqlCommand(sqlSporring, tilkobling)
            sql.Parameters.AddWithValue("@brukernavn", brukernavn)
            sql.Parameters.AddWithValue("@passord", passord)




            'Angir variabel for leser. Leser av det gitte resultatet for spørringen.
            Dim leser = sql.ExecuteReader()

            'leser hvilken rolleId brukeren har
            Dim brukere = "rolle: "
            While leser.Read()
                rolleId &= leser("rolleId") & " "
                f_nr &= leser("f_nr") & " "
                fornavn &= leser("fornavn") & " "
            End While

            'info som blir henta på minside for og se hvem som er pålogget
            Label6.Text = f_nr
            Label5.Text = fornavn


            'sjekker hvilken rolleid brukeren har og dermed sender brukeren til sin side.
            If rolleId = 1 Then
                DonorMinSidevb.Show()
            ElseIf rolleId = 2 Then
                HelsepersonellMinSide.Show()
            ElseIf rolleId = 3 Then
                AdministrasjonMinSide.Show()
            Else
                MsgBox("Feil brukernavn/passord")
            End If


            'If-setning som forteller om tilkoblingen er vellykket eller ikke.
            If leser.HasRows Then 'Om spørringen returnerer rader.

                Label3.Text = brukernavn 'Vis brukernavn i en label.
            Else 'Om spørringen ikke returnerer noen rader.
                MsgBox("Feil brukernavn eller passord") 'Vis feilmelding.
            End If

            leser.Close() 'Lukk leseren.
        Catch feilmelding As Exception
            MsgBox("Feil ved tilkobling eller feil brukernavn/passord: " & feilmelding.Message)
        Finally
            tilkobling.Dispose()
        End Try


    End Sub

    '"Registrer legetime" - knapp.
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim f2 As New Form2 'Angir variabel for form 2.

        'Om knappen trykkes, vises form 2. 
        f2.Show()


    End Sub


End Class
