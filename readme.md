# **JimmaNeo**

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
</details>

# 1.1. **Storyboard**   
![Screenshot Storyboard](/Documentation/Screenshots/LMU_Team_F_Storyboard-Vesion_1.2-001.jpg)   

# 2. **Anwendungsbeschreibung**

## Allgemeiner Bereich:
<br>

### LandingPage 
Beim Starten der Web-Anwendung kann man auf der linken Seite der Anwednung die Navigation sehen und  
auf der rechten Seite die LandingPage der Applikation **JimmaNeo** sehen.  
Hier kann man als Einstieg nochmal das Storyboard in Form eines kleinen Videos ansehen.  
Des Weiteren kann man beim runterscrollen Details zu unserem Projekt lesen.
<br>  
![Screenshot LandingPage](/Documentation/Screenshots/Home.PNG)
<br>

### Navigationspunkt: News
Hier werden alle neuen News angezeigt.
<br>    
![Screenshot News](/Documentation/Screenshots/News.PNG)
<br>

### Navigationspunkt: Login  
Wenn man sich einlogt, ist es nicht relevant,   
welche Rolle (Teacher, Student, Admin) man besitzt.    
Die Anwendung filtert die Rolle beim Login automatisch.
<br>   
![Screenshot Login](/Documentation/Screenshots/Login.PNG)
<br>

### Navigationspunkt: Register   
Hier kann man sich registrieren, wenn man noch keinen Account besitzt.  
Alle neu registrierten Benutzer besitzen automatisch die Studenten Berechtigung. 
<br>  
![Screenshot Register](/Documentation/Screenshots/Register.PNG)
<br>

### Navigationspunkt: Contact us   
Wenn man Anregungen, Wünsche oder auch Anmerkungen zu der Applikation hat, kann man jederzeit
diese im Kontaktformular verfassen und abschicken.  
<br> 
![Screenshot Contact](/Documentation/Screenshots/Contact.PNG)
<br>

### Navigationspunkt: FAQ  
Wichtige Fragen und Antworten zu der Anwendung. 
<br>  
![Screenshot FAQ](/Documentation/Screenshots/FAQ.PNG)
<br>


## Admin Bereich:

Wenn man sich erfolgreich eingelogt hat und Admin Rechte besitzt,  
gelangt man auf die ManageUser Seite.  
Hier sieht man eine Tabelle mit allen registrierten Benutzern auf der Plattform.   
In jeder Zelle der Tabelle befindet sich neben dem Usernamen, Vornamen,  
Nachnamen ein Edit Button(blau) und ein Delete Button(rot).  
<br> 
![Screenshot ManageUser](/Documentation/Screenshots/Admin_ManageUser.png)
<br>

Nun hat man drei Optionen zur verfügung, wie man als Admin weiter verfahren kann.   
<br>

### 1. Einen Benutzer löschen    
Um einen Benutzer zu löschen, klicken man auf den roten Button.
Danach wird man nochmal gefragt, ob man den ausgewählten Benutzer wirklich löschen möchte.
Durch erneutes klicken des Delete Buttons löscht man den Benutzer endgültig aus dem System.
<br> 
![Screenshot DeleteUser](/Documentation/Screenshots/Admin_DeleteUser.PNG)
<br> 

### 2. Einen Benutzer editieren   
Um den Vornamen, Nachnamen oder die Rolle eines Benutzers zu ändern, klickt man neben den  
gewünschten Benutzer auf das Zahnrad (blauer Button).   
Man gelangt nun auf die EditSeite des ausgewählten Benutzers.
<br> 
![Screenshot EditUser](/Documentation/Screenshots/Admin_EditUser_Role.png)
<br>

### 3. Eine neue Nachricht erstellen   
Wenn man eine neue Nachricht erstellen möchte, klickt man auf der ManageUser Seite  
auf den grauen Button EditNews. Nun wird man weitergeleiet auf die editierbare News Seite. 
<br>      
![Screenshot EditNews](/Documentation/Screenshots/Admin_EditNews.png)

### Prozessablauf

<br>    
![Screenshot EditNews](/Documentation/Screenshots/AdminArea.png)

## Trainer Bereich:

**1. WelcomeTrainer**

Nachdem Login eines Trainers landet dieser auf der Welcometrainer Seite. Zum einen werden die Resultate der vorhandenen Tests in einer Tabelle veranschaulicht, zum anderen erhält jeder Trainer die Möglichkeit einen Einblick in die Videos: "How to lectures" und "How to tests". Diese erläutern wie Lectures und Tests erstellt und gestartet werden.

![Screenshot EditUser](/Documentation/Screenshots/WelcomeTeacherPage.png)

**2. Test Overview**

Es wird eine Übersicht über alle Tests aufgezeigt.     
![Screenshot EditUser](/Documentation/Screenshots/TestOverview.png)

**3. Test Editor**

Die Tests können über den Test-Editor bearbeitet sowie hinzugefügt werden.
Hier wird das Topic des Tests festgehalten sowie die Fragestellungen und die weiterführenden Informationen über das Thema(Further informations).  
Es können zudem Youtube Videos zum Testdurchlauf hinzugefügt werden.
![Screenshot EditUser](/Documentation/Screenshots/TestEdit.png)

**Add Questions:**
Fragen und Antworten können hier eingefügt werden, es ist zudem möglich Bilder zu den Fragen hinzuzufügen und man kann pro Frage eine Erklärung der Lösung angeben die in der Auswertung des Tests angezeigt wird.

![Screenshot EditUser](/Documentation/Screenshots/AddQuestionsandAnswers.png)

**Add Further Informations:**
Zusätzliche Informationen über das Testthema können hier eingebunden werden über Website-Links, Youtube-Videos und Bilder.

![Screenshot EditUser](/Documentation/Screenshots/AddFurtherInformation.png)

**Prozessablauf Tests**     
![Screenshot EditUser](/Documentation/Screenshots/TrainerTest.png)

**4. LectureOverview**

Die LectureOverview ermöglicht einen Trainer Lectures zu erstellen, bearbeiten, löschen oder starten. Die Suchleiste ermöglicht eine zügige Lecturesuche.

![Screenshot EditUser](/Documentation/Screenshots/LectureOverviewPage.png)

**5. LectureEdit**

Auf der LectureEdit-Seite ist es möglich Informationen in Text-, Video- oder Bildform für die Lecture bereitzustellen. Ebenso können Tests mit der Lecture in Verbindung gesetzt werden, dies geschieht über die Test-ID.

![Screenshot EditUser](/Documentation/Screenshots/LectureEditPage.png)

**Prozessablauf Lectures**
![Screenshot EditUser](/Documentation/Screenshots/TeacherLecture.png)

## Student Bereich:   

**1. Studentarea**<br>
Die Studentarea zeigt dir interessate Statisiken über deinen Testergebnisse und Fortschritt in Lectures. 
Außerdem gibt es die Möglichkeit dir selbst To-do's zu erstellen um immer den Überblick zu behalten.
Die neusten Nachrichten über neue Lectures und Test wird dir hier auch angezeigt. 
Zu guter letzt kannst du auf dem grünen Herzen Feedback und Bugs an den Support schicken.
![Screenshot EditUser](/Documentation/Screenshots/StudentArea.jpg)

**2. Overviews**<br>
Diese Seites zeigen dir einen Überblick über alle Lectures bzw. Tests.

![Screenshot EditUser](/Documentation/Screenshots/LectureOverviewStudent.jpg)
![Screenshot EditUser](/Documentation/Screenshots/TestOverviewStudent.jpg)

**3. Run Lectures**<br>
Die Lectures vermitteln dir neues Wissen.
![Screenshot EditUser](/Documentation/Screenshots/RunLectureVideo.jpg)
![Screenshot EditUser](/Documentation/Screenshots/RunLectureBildUndText.jpg)

**4. Run Test**<br>
Die Test geben dir die Möglichkeit dein Wissen auf die Probe zu stellen.
![Screenshot EditUser](/Documentation/Screenshots/RunTestVideo.jpg)
![Screenshot EditUser](/Documentation/Screenshots/RunTestFragen.jpg)

**5. Test Results**<br>
Hier werden deine Ergebnisse des abgeschlossenen Test angezeigt.
![Screenshot EditUser](/Documentation/Screenshots/TestResult.jpg)

**6. Further Informationen** <br>
Falls du noch mehr lernen möchstest hast du die Möglichkeit auf weitere Informationen zuzugreifen.
![Screenshot EditUser](/Documentation/Screenshots/TestFurtherInfo.jpg)

**Prozessablauf**<br>
![Screenshot EditUser](/Documentation/Screenshots/StudentDiagram.jpg)<br>

# 3. **Softwarearchitektur**   

**Struktur** <br>
Die Anwendung ist in drei Teile aufgegliedert.   Das Frontend, die Client-Seite, befindet sich in dem „SEIIApp.Client“-Projekt, einer WebApp-Anwendung.   Das Backend, die Server-Seite, wird in dem „SEIIApp.Server“-Projekt implementiert.   Das „SEIIApp.Shared“-Projekt dient dem Datenaustausch mithilfe von DataTransferObjects (DTOs).<br><br>
**Datenzugriff** <br>
Um auf die im Backend gespeicherten Daten zuzugreifen, nutzen die Razor-WebPages die im Frontend vorhandenen BackendAccessServices.    Diese schicken DataTransfer-Objekte an die jeweiligen Controller im Backend, welche die weitere Verarbeitung in Hinblick auf die Daten und der Datenbank übernehmen.    Die Controller bieten die HTTP-Schnittstelle nach dem REST-API-Schema an und geben die erhaltenen Requests an die jeweiligen Services weiter, welche für die verschiedenen Aktionen auf der Datenbank zuständig sind. <br><br>
**Services und Controller** <br>
Folgend sind die Services und Controller einschließlich ihrer Methoden und ihrer Zuordnung zu dem Front- und Backend angegeben:   

![Screenshot Services_&_Controller](/Documentation/Screenshots/services_controller.png)<br>

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

![Screenshot Gruppenfoto](/Documentation/Screenshots/Gruppenfoto.JPG)

 

### 5. **Anlagen**

**[Storyboard](/Documentation/LMU_Team_F_Storyboard-Vesion_1.2.pdf)**    
**[PressRelease](/Documentation/LMU_TEAM_F_PR.pdf)**   
**[FAQs](/Documentation/FAQs.pdf)**

