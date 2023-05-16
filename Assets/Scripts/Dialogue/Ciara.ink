INCLUDE Globals.ink
{ciara_reading == true: -> fantasy}
{ciara_completed == true: -> complete}
->intro
=== intro ===
Hello. #speaker:Ciara #portrait:ciara_neutral #player portrait:noxie_neutral #layout:right
Do you need something?
(Oh no. I didn't think this far ahead.) #speaker:Noxie #layout:left
//Hey, can you share your essence with me? #speaker:Noxie #layout:left
//Uh, that's a bit forward... #speaker:Ciara #layout:right
//(Maybe I should get to know her first.) #speaker:Noxie #layout:left #player portrait:noxie_thinking
->Q

=== Q ===
* [Ask about what she's doing] -> ask
* [Ask about hobbies] -> hobbies
->END

=== ask ===
So... whatcha doin? #speaker:Noxie #layout:left
Tending to the flock. #speaker:Ciara #layout:right
Oh. Why? #speaker:Noxie #layout:left
Because... It's my job. #speaker:Ciara #layout:right
The birds can't protect themselves, so that's why I'm here.
I guess I get to sell the eggs and loose feathers.
A job... that's... great... I guess? #speaker:Noxie #layout:left
Sure. #speaker:Ciara #layout:right
Are you done bothering me now?
//~ ciara_met = true
->Q

=== hobbies ===
What do you like to do for fun? #speaker:Noxie #layout:left
Why are you asking me this. #speaker:Ciara #layout:right
To like... get to know you, right? #speaker:Noxie #layout:left
Look, I'm busy right now. #speaker:Ciara #layout:right
If it will satisfy you, I like to read.
Oh, okay. Read about what? #speaker:Noxie #layout:left
It doesn't matter. #speaker:Ciara #layout:right
Not like I'd expect you to understand anyway.
~ ciara_met = true
->Q

=== fantasy ===
Have you ever read "The Witch's House"? #speaker:Ciara #portrait:ciara_neutral #player portrait:noxie_neutral #layout:left
~ essence_name = "Ciara"
~ essence_activate = true
~ ciara_completed = true
->END

=== complete ===
I would love to hear about your human escapades. #speaker:Ciara #portrait:ciara_neutral #player portrait:noxie_neutral #layout:right
Ha ha... yeah........ #speaker:Noxie #layout:left
maybe later....... 
->END