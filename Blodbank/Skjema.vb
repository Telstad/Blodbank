Imports MySql.Data.MySqlClient 'Importerer SQL referanse.

Public Class Skjema
    Public teller As Integer 'Global variabel for teller.
    Public feilmelding_besvar As String = "Vennligst besvar alle spørsmålene før du fortsetter."
    Public kvinne As Boolean 'Variabel for å finne ut om brukeren er ett av kjønnene.
    Public sporringSpm As String 'Variabler for spørring som skal sette inn verdier.
    Public sporringSvar As String 'Variabel for spørring som skal sette inn verdier.

    Dim tilkobling As New MySqlConnection("Server = mysql.stud.iie.ntnu.no;" _
                                               & "Database = g_oops_04;" _
                                               & "Uid = g_oops_04;" _
                                               & "Pwd = W1TzS2W4") 'Definerer en ny tilkobling.



    'Ved innlasting av skjema. 
    Private Sub Skjema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnTilbake.Enabled = False 'Gjør tilbakeknappen utilgjengelig ved oppstart, slik at brukeren ikke kan gå bak og ut av skjema.

        'Ved å implementere følgende ved innlastning, vil ikke 'header' delen av skjemaet vises. Ved å gjøre dette kan ikke brukeren trykke seg til de ulike sidene, men tvinges til å bruke knappene.
        '.. REFERANSE: https://tinyurl.com/n4qrkpz (Sist sjekket: 17.01.17)
        Tabskjema.Region = New Region(New RectangleF(TabInfo.Left, TabInfo.Top, TabInfo.Width, TabInfo.Height))



    End Sub

    Function hentgroupbox(p As Panel) 'Funksjon for å hente alle gruppebokser. Bruker må angi hvilket panel som skal gjennomgås.

        For Each boks As GroupBox In p.Controls 'For hver gruppeboks i panelet.

            For Each knapp As RadioButton In boks.Controls 'For hver knapp i hver av gruppeboksene.
                If knapp.Checked Then 'For hver knapp som er avkrysset.
                    teller += 1 'Legg til én i telleren.

                    tilkobling.Open() 'Åpner kobling.

                    'SQL for hvilken tabell som skal fylles ut
                    sporringSvar = "INSERT INTO svar"
                    sporringSvar = sporringSvar & "(svar_tekst)"
                    sporringSvar = sporringSvar & "VALUES"
                    sporringSvar &= "('" & knapp.Tag & "')"

                    Dim insertSvarSql As New MySqlCommand(sporringSvar, tilkobling)
                    Dim daSvar As New MySqlDataAdapter
                    Dim svarTabell As New DataTable

                    daSvar.SelectCommand = insertSvarSql
                    daSvar.Fill(svarTabell) 'Dytter innhold i tabell.

                    tilkobling.Close() 'Lukker kobling.

                End If
            Next
        Next

    End Function

    Function HentSporsmaal(p As Panel)
        tilkobling.Open()

        For Each s In p.Controls

            sporringSpm = "INSERT INTO spm"
            sporringSpm = sporringSpm & "(spm_tekst)"
            sporringSpm = sporringSpm & "VALUES"
            sporringSpm &= "('" & s.text & "')"

            Dim insertSpmSql As New MySqlCommand(sporringSpm, tilkobling)
            Dim daSpm As New MySqlDataAdapter
            Dim spmTabell As New DataTable

            daSpm.SelectCommand = insertSpmSql
            daSpm.Fill(spmTabell)

        Next

        tilkobling.Close()
    End Function

    'Lager en funksjon for 'Neste'-knappen.
    Function neste()

        Tabskjema.SelectedIndex += 1 'Hovedfunksjonen for denne funksjonen er å flytte brukeren fremover i skjemaet. 
        '..Gjør dette ved å finne brukerens nåværende indeks og inkrementerer den med 1 for hver gang funksjonen kalles.

        'Om indeksen i skjemaet er større enn 0, dvs alt etter infoteksten.
        If Tabskjema.SelectedIndex > 0 Then
            btnTilbake.Enabled = True 'Gjør tilbakeknappen tilgjengelig.
        End If

        'Om indeksen til skjemaet ligger på 2, dvs om brukeren er ferdig med første runde med spørsmål.
        If Tabskjema.SelectedIndex = 2 Then

            'Alle de ulike radioknappene ligger i 'gruppebokser'(groupbox), og gruppeboksene ligger inne i et panel. (Velger å bruke panel fordi en ekstra groupbox ikke ser like estetisk godt ut)
            '... Dette er gjort fordi på denne måten vil det være betraktelig enklere å begytte seg av en nøstede løkker for å sjekke svarene til brukeren.
            '... Alternativet ville ha vært å brukt 6 if-setninger eller 6 løkker, noe som er dårlig programmeringsskikk.
            teller = 0

            hentgroupbox(SporsmaalPanel)

            If teller < 6 Then 'Om telleren er under antall spørsmål som trengs å besvares. 
                Tabskjema.SelectedIndex -= 1 'Hopp tilbake.
                MessageBox.Show(feilmelding_besvar) 'Feilmelding.

            Else

                HentSporsmaal(spmPanel1) 'Kaller på funksjon og henter spørsmål 

            End If

        End If

        If Tabskjema.SelectedIndex = 3 Then 'Om indeksen til brukeren er på 3, dvs om brukeren skal fortsette til det tredje spørsmålspanelet. 

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2.indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel2)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)
            Else

                HentSporsmaal(spmPanel2)

            End If

        End If

        If Tabskjema.SelectedIndex = 4 Then 'Om indeksen til brukeren er på 4, dvs om brukeren skal fortsette til det fjerde spørsmålspanelet. 

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2.indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel3)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel3)

            End If
        End If

        If Tabskjema.SelectedIndex = 5 Then 'Om indeksen til brukeren er på 5, dvs om brukeren skal fortsette til det femte spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2.indeksen for utfyllende forklaring og grunnet valg av metoder. 

            teller = 0

            hentgroupbox(SporsmaalPanel4)


            If teller < 6 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel4)

            End If

        End If

        If Tabskjema.SelectedIndex = 6 Then 'Om indeksen til brukeren er på 6, dvs om brukeren skal fortsette til det sjette spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2.indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel5)

            If teller < 6 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel5)

            End If


        End If

        If Tabskjema.SelectedIndex = 7 Then 'Om indeksen til brukeren er på 7, dvs om brukeren skal fortsette til det sjuende spørsmålspanelet. 

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            'Trenger bare én for-løkke, ettersom at det bare er ett spørsmål som må besvares i denne delen av skjemaet.
            For Each knapp As RadioButton In gb29.Controls
                If knapp.Checked Then
                    teller += knapp.Tag
                End If
            Next

            If teller = 0 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel6)

            End If

        End If

        If Tabskjema.SelectedIndex = 8 Then 'Om indeksen til brukeren er på 8, dvs om brukeren skal fortsette til det åttende spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel6)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel7)

            End If

        End If

        If Tabskjema.SelectedIndex = 9 Then 'Om indeksen til brukeren er på 9, dvs om brukeren skal fortsette til det niende spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel7)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel8)

            End If

        End If

        If Tabskjema.SelectedIndex = 10 Then 'Om indeksen til brukeren er på 10, dvs om brukeren skal fortsette til det tiende spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel8)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel9)

            End If

        End If

        If Tabskjema.SelectedIndex = 11 Then 'Om indeksen til brukeren er på 11, dvs om brukeren skal fortsette til det ellevte spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            For Each knapp As RadioButton In gb45.Controls

                If knapp.Checked Then
                    teller += knapp.Tag
                End If

            Next

            Select Case teller 'Bruker select-case-setning for å bestemme hvilket skjema brukeren skal føres til.
                Case 0 'Om telleren er 0, altså brukeren har ikke valgt et kjønn. Se kode for 2. indeks for mer info angående valg og funksjonalitet av kode.
                    Tabskjema.SelectedIndex -= 1
                    MessageBox.Show(feilmelding_besvar)
                Case 2 'Om telleren er 2, altså om brukeren velger "mann"
                    Tabskjema.SelectedIndex += 1 'Hopp over ett skjema, slik at brukeren får vist skjemaet som skal besvares av menn.
                    kvinne = False 'Setter kvinne til false slik at programmet ved at brukeren er en mann.
                Case Else
                    kvinne = True 'Om ingen av de ovenfor betyr dette at brukeren er kvinne.
            End Select

        End If

        'Forhindrer at brukeren klarer å hoppe til et skjema som er kjønnsbestemt.
        'Sjekker om brukern har svart på alle spørsmålene for kvinne (om brukeren er kvinne).
        If Tabskjema.SelectedIndex = 12 And kvinne = True Then

            Tabskjema.SelectedIndex += 1 'Hopper over spørreskjema for menn.

            teller = 0

            hentgroupbox(SporsmaalPanelKvinne)

            If teller < 4 Then
                Tabskjema.SelectedIndex -= 2
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel10)

            End If

        End If

        If Tabskjema.SelectedIndex = 13 And kvinne = False Then 'Om brukeren skal hoppe videre fra spørreskjemaet til mann.

            teller = 0

            For Each knapp As RadioButton In gb50.Controls

                If knapp.Checked Then
                    teller += 1
                End If

            Next

            If teller = 0 Then
                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel11)

            End If

        End If

        If Tabskjema.SelectedIndex = 14 Then 'Om indeksen til brukeren er på 14, dvs om brukeren skal fortsette til det fjortende spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel9)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel12)

            End If


        End If

        If Tabskjema.SelectedIndex = 15 Then 'Om indeksen til brukeren er på 15, dvs om brukeren skal fortsette til det femtende spørsmålspanelet.

            'Bruker samme gang for koden i denne indeksen. Referer til den kommenterte koden i den 2. indeksen for utfyllende forklaring og grunnet valg av metoder.

            teller = 0

            hentgroupbox(SporsmaalPanel10)

            If teller < 5 Then

                Tabskjema.SelectedIndex -= 1
                MessageBox.Show(feilmelding_besvar)

            Else

                HentSporsmaal(spmPanel13)

            End If

        End If


        Return Tabskjema.SelectedIndex 'Returnerer den nåværende indeksen. Dette kan være nyttig ettersom vi skal kunne vite hvor langt brukeren er kommet.

    End Function

    Function tilbake() 'Funksjon for 'Tilbake'-knapp

        Tabskjema.SelectedIndex -= 1 'Hovedfunksjonen for denne funksjonen er å flytte brukeren bakover i skjemaet. 
        '...Hensikten med dette er slik at om brukeren vil endre på sine svar, vil det være mulighet for å gjøre dette. 
        '...Denne funksjonen finner brukerens nåværende indeks, og dekrementerer indeksen med 1.

        teller = 0 'Resetter telleren. Ved å gjøre dette vil ikke telleren få en større verdi enn det den skal.

        Select Case Tabskjema.SelectedIndex 'Bruker select-case og setter den nåværende indeksen som utgangspunkt.
            Case < 1 'Om indeksen er 1, altså om brukeren er på den første siden av skjemaet. 
                btnTilbake.Enabled = False 'Gjør tilbakeknappen utilgjengelig.
            Case 11 'Indeksen er 11, altså om brukeren skal gå tilbake fra spørsmålene for menn.
                Tabskjema.SelectedIndex -= 1 'Hopp over foregående skjema og gå helt tilbake til skjemaet for å velge kjønn. 
            Case 12 And kvinne = True 'Forhindrer brukeren å hoppe til et skjema som er kjønnsbestemt. 
                Tabskjema.SelectedIndex -= 1
        End Select

        Return Tabskjema.SelectedIndex 'REFERANSE: samme hensikt som i return-verdien i 'Neste'-funksjonen.
    End Function

    'Knapp for å gå videre i skjemaet.
    Private Sub btnNeste_Click(sender As Object, e As EventArgs) Handles btnNeste.Click

        neste() 'Kaller på 'neste'-funksjonen.

    End Sub

    'Knapp for å hoppe bakover i skjemaet.
    Private Sub btnTilbake_Click(sender As Object, e As EventArgs) Handles btnTilbake.Click

        tilbake() 'Kaller på tilbake-funksjonen.

    End Sub
End Class