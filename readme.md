# Vorlagenprojekt für ein Blazor WebAssembly Projekt das auf ASP.NET Core gehostet ist

Dieses Projekt ist ein Standard-Vorlageprojekt, das eine funktionierende WebAssembly-Anwendung, die auf .NET Core gehostet ist, zeigt. Die Beispiel-Anwendung enthält einen Zugriff auf APIs.


# 1. **PressRelease**

**LMU Klinikum stellt das JimmaNeo Projekt vor:  
Flexibel fortbilden im Bereich Neonatologie durch länderübergreifende
Zusammenarbeit**

_Eine besondere Austauschplattform für Lehrende und Lernende, welche dabei hilft die  
medizinische Versorgung von Neugeborenen zu verbessern_

Die brandneue Applikation für „JimmaNeo“ verspricht eine mobile, schnelle und flexible  
Aneignung der Themenbereiche der Neonatologie für die Mitarbeiter, um langfristig die  
Sterberate von Neugeborenen zu reduzieren.

Das Projekt hat sich zum Ziel gesetzt die hohe Sterberate von Neugeborenen in Äthiopien zu  
verringern. Sie liegt bei 5,8% und ist in etwa zwanzigmal höher als in Deutschland.  

Eduardo Holmes ein Krankenpfleger in Jimma, Äthiopien:  
> „Es gibt hier einfach nicht genug gut geschultes Personal um alle Neugeborenen ausreichend  
> medizinisch zu versorgen. Die Applikation im Rahmen des JimmaNeo Projekts bietet eine  
> gute Möglichkeit das Personal besser zu schulen und gemeinsam zu trainieren.“

Durch diese neuartige Art des Wissensaustausches ist es dem Personal in der Neonatologie  
möglich ihr Wissen und ihre Kenntnisse im Bereich der Neonatologie zu schulen und zu  
verbessern. Wissensquellen können frei zur Verfügung gestellt werden, um das Wissen so  
dem Fachpersonal frei zugänglich zu machen.

Interessiertes Fachpersonal der Neonatologie erhält die Möglichkeit durch diese E-Learning  
Plattform sich medizinische Themen in Form von Lektionen mit anschließenden Tests  
anzueignen. Der Fokus hierbei liegt auf der gezielten Reflektion der Testergebnisse, um  
auftretender Wissenslücken zu schließen. Dieses Feature wird von ausführlicherer  
Erläuterung, in Form von maßgeschneiderten Erklärungen und Verlinkung zu  
Informationsquellen umgesetzt.  

George Micheals, frisch gebackener Vater und Industrieangestellter:  
> "Meine Tochter Aba wurde kurz nach ihrer Geburt krank. Ohne genügend Wissen in der  
> Neonatologie hätte das Krankenhaus nichts für meine Tochter tun können. Durch die  
> Unterstützung der internationalen Zusammenarbeit im Rahmen des JimmaNeo Projektes wird  
> Wissen und Training dem Fachpersonal der Neonatologie leicht zugänglich gemacht."  


Damit auch zukünftig viele Neugeborene wie Aba gerettet werden können müssen Projekte  
wie das JimmaNeo Projekt an Bekanntheit gewinnen. Bitte berichtet in eurem Umfeld über  
über dieses Projekt. Weitere Informationen findet ihr unter URL: [LMU](https://www.lmuklinikum.de).

# 2. **Anwendungsbeschreibung**

### Allgemeiner Bereich:
Beim Starten der Web-Anwendung können Sie auf der linken Seite der Anwednung die Navigation sehen.  
Sie gelangen auf der Hauptseite zur LandingPage **JimmaNeo**.  
Hier können Sie zum Einstieg nochmal das Storyboard in Form eines kleinen Videos ansehen.  
Des Weiteren können Sie Details zu dem Projekt lesen.    
![Screenshot LandingPage](/Documentation/Screenshots/Home.PNG)

**- Navigationspunkt: News**    
Hier können Sie alle neuen Nachrichten durchlesen.    
![Screenshot News](/Documentation/Screenshots/News.PNG)

**- Navigationspunkt: Login**  
Hier können Sie sich einlogen, dabei ist es nicht relevant,   
welche Rolle (Teacher, Student, Admin) Sie besitzen.    
Die Anwendung filtert Ihre Rolle beim Login automatisch.  
![Screenshot Login](/Documentation/Screenshots/Login.PNG)

**- Navigationspunkt: Register**  
![Screenshot Register](/Documentation/Screenshots/Register.PNG)

**- Navigationspunkt: Contact us**  
![Screenshot Contact](/Documentation/Screenshots/Contact.PNG)

**- Navigationspunkt: FAQ**  
![Screenshot FAQ](/Documentation/Screenshots/FAQ.PNG)



## Admin Bereich:  
Wenn Sie sich erfolgreich eingelogt haben und Admin Rechte besitzen,  
gelangen Sie auf die ManageUser Seite.  
Hier wird Ihnen eine Tabelle mit allen registrierten Benutzern auf der   
Plattform angezeigt. 
In jeder Zelle der Tabelle befindet sich neben dem Usernamen, Vornamen,  
Nachnamen ein Edit Button(blau) und ein Delete Button(rot)
![Screenshot ManageUser](/Documentation/Screenshots/Admin_ManageUser.png)

Nun stehen Ihnen drei Optionen zur verfügung, wie Sie weiter verfahren können.  

**1. Einen Benutzer löschen**    
Um einen Benutzer zu löschen, klicken Sie auf den roten Button.
Danach werden Sie nochmal gefragt, ob Sie den ausgewählten Benutzer wirklich löschen wollen.
Durch erneutes klicken des Delete Buttons löschen Sie den Benutzer endgültig aus dem System.
![Screenshot DeleteUser](/Documentation/Screenshots/Admin_DeleteUser.PNG)

**2. Einen Benutzer editieren**    
Um den Vornamen, Nachnamen oder die Rolle eines Benutzers zu ändern, klicken Sie neben den  
gewünschten Benutzer auf das Zahnrad (blauer Button).   
Sie gelangen nun auf die EditSeite des spezifischen Benutzers.
![Screenshot EditUser](/Documentation/Screenshots/Admin_EditUser_Role.png)

**3. Eine neue Nachricht erstellen**   
Wenn Sie eine neue Nachricht erstellen wollen, klicken Sie auf der ManageUser Seite  
auf den grauen Button EditNews.  
![Screenshot EditNews](/Documentation/Screenshots/Admin_EditNews.png)

**Prozessablauf**  
![Screenshot EditNews](/Documentation/Screenshots/AdminArea.png)

## Trainer Bereich:
**Prozessablauf Tests**     
![Screenshot EditUser](/Documentation/Screenshots/TrainerTest.png)

## Student Bereich:   




# 3. **Softwarearchitektur**


# 4. **Team und Ansprechpartner**

| Teammitglieder | Bereich |Ansprechpartner
| ------ | ------ |------ |
| Adamczyk, Xaver | Backend |------ |
| Le, Hoang Long| Frontend |------ |
| Maghy, Sara  | Frontend |------ |
| Malczak, Ralf | Frontend |------ |
| Volland, Aaron  | Frontend |avolland@hm.edu|
| Weber, Anne Sofie | Frontend |------ |  
| Wolf, Simon  | Backend |------ | 
 

### 5. **Anlagen**

**[Storyboard](/Documentation/LMU_Team_F_Storyboard-Vesion_1.2.pdf)**    
**[PressRelease](/Documentation/LMU_TEAM_F_PR.pdf)**   
**[FAQs](/Documentation/FAQs.pdf)**

