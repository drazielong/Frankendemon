INCLUDE globals.ink
Thank you for coming to visit. #speaker:Pedia #portrait:pedia_neutral #player portrait:noxie_neutral #layout:right
This is the Blackthorn library. 
How may I help you?

//if noxie has met ciara
//ask about her reading history
{ana_met == true: 
* [Ask for elephant pictures] -> ana
}
* [Talk to Pedia] -> comics

=== ana  ===
I’m looking for elephants. #speaker:Noxie #layout:left #player portrait:noxie_neutral

Yes, we do have books on those in the human section. #speaker:Pedia #layout:right 
Is there anything in particular you need?

...I need a picture of an elephant. #speaker:Noxie #layout:left

Certainly. I have zoology books, children’s books, #speaker:Pedia #layout:right

Just give me the first thing you got. #speaker:Noxie #layout:left

Of course. #speaker:Pedia #layout:right
~ cutscene = true

Whoa. #speaker:Noxie #layout:left
~ cutscene = false
Uh, thanks. 

Have a good day. #speaker:Pedia #layout:right
~ ana_reading = true
~ ana_met = false
->END

=== comics ===
Hello #speaker:Pedia #layout:right
{ana_reading == true:
Can you do that puppet string thing again? #speaker:Noxie #layout:left
}
{ana_reading == false: You have a lot of books here.} #speaker:??? #layout:left
... #speaker:Pedia #layout:right
->END