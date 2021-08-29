# Проект по визуелно програмирање - Memory Game - Горазд Димовски 186009
## Опис на апликацијата
Станува збор за едноставна игра на меморија. Постојат 16 квадратчиња позади кои се кријат 8 пара идентични симболи. Со обичен клик на квадратчето симболот се открива и е 
потребно да се пронајде неговиот идентичен пар. По два последователни клика доколку двата симболи не се совпаѓаат тие повторно се превртуваат. Играчот игра се додека не ги пронајде
сите 8 пара идентични симболи. Апликацијата му ги брои чекорите на играчот како и времето потребно да ги најди сите симболи. Кога ќе ја заврши играта има опција да започне од
почеток или да излезе од апликацијата. Апликацијата има копче New Game кое ја рестартира играта со нови 16 симболи. 

<img src="https://user-images.githubusercontent.com/63555005/131264421-efd2538f-bdce-49a1-bbff-74db30aefec1.JPG" alt="startingPhoto" width="325" height="250">
<img src="https://user-images.githubusercontent.com/63555005/131264599-00a76803-0804-47f1-9ab0-d072af85968e.JPG" alt="lookingForMatch" width="325" height="250">
<img src="https://user-images.githubusercontent.com/63555005/131264593-01640097-e809-4dc1-8548-24952e7c67cf.JPG" alt="gameFinished" width="325" height="250">

## Техничко решение на апликацијата
 Label first, second;   - <b>помошни лабели за да се памтат кликнатите квадратчиња</b>  
 Random random = new Random(); - <b>рандом константа за рандом генерирање на симболите</b>  
 int movesMade = 0; - <b>променлива за броење на потезите на играчот</b>  
 System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch(); - <b>стоперица за изминатото време од почетокот на играта </b>  
 #
  private List<char> generatePictures()  
      <b>Функција која генерира 8 пара рандом броеви. Сите парови се различни еден од друг. Рандом броевите ги претворува во карактери кои ги преставуваат симболите благодарејќи           на
      фонтот „Wingdings“</b>    
 #

 
  
   private void timer1_Tick(object sender, EventArgs e)  
        <b>Тик функција на тајмер којa се користи за да се определи колку долго двa погрешно спарени симболи ќе останат превртени пред повторно да се скријат</b>  
  
 #
     
  private void StartGame()   
       <b>Функција за започнување на играта.</b>  
 
    
  #
  private void timer2_Tick(object sender, EventArgs e)    
        <b>Тајмер за изминатото време на играње.</b>    
 
      
   #
   
  
  private void newGame_Click(object sender, EventArgs e)      
        <b>Функција за копчето New Game.</b>  
 
      
  #
  private void CheckWin()   
         <b>Функција која проверува дали играчот ја завршил играта односно дали ѓи пронајдол сите парови на симболи</b>    
 
    
         
  #
  private void label_click(object sender, EventArgs e)  - <b>Главната функција на задачата која се активира при секој клик на квадратче </b>     
    {    
            if (first != null && second != null)  
              return; - Се осигура дека нашата апликација регистрира само две кликнати квадратчиња (Грешка може да се јави во краткиот интервал каде што два погрешно спарени симболи се превртени и играчот кликнува трет)  
 
            Label clicked = sender as Label;  
            if (clicked == null)  
                return;  - ако не кликнеме на лабела излегуваме од функцијата  

            if (clicked.ForeColor == Color.Black)  
                return;  - ако кликнеме откриено квадратче излегуваме од функцијата  

            if (first == null)  
            {  
                first = clicked;  
                first.ForeColor = Color.Black;  
               return; - го откриваме симболот со тоа што ја менуваме бојата на фонтот (која претходно се совпаѓа со бојата на квадратчето) и запамтуваме дека е овој симбол е кликнат ПРВ    
            }  

            second = clicked;  
            second.ForeColor = Color.Black; - менуваме бојата на втор по ред кликнат симбол  

            movesMade++; - кога се кликнати последователно две симболи односно кога е пробано да се направи пар се зголемува бројачот на потези  
            lblNumberMoves.Text = movesMade.ToString(); - се променува лабелата за бројот на потези за да одговара со соодветниот бројач  
            CheckWin(); - после секој направен потег се проверува дали играта е завршена односно дали се пронајдени сите парови на симболи  
            
  
            if(first.Text == second.Text)  
            {  
                first = null;  
                second = null; 
            }  
            else  
                timer1.Start();  - доколку двата кликнати симболи се совпаѓаат помошните покажувачи се ресетираат , а доколку не се совпаѓаат се користи тајмер кој одлучува колку                 долго ќе бидат превртени симболите пред да се скријат  
            
    }  
 




