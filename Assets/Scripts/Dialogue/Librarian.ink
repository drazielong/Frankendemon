INCLUDE globals.ink
Thank you for coming to visit. #speaker:Pedia #portrait:default #player portrait:noxie_neutral #layout:right
This is the Blackthorn library. 
How may I help you?

//if noxie has met ciara
//ask about her reading history
{ciara_met == true: 
* [Ask about Ciara] -> ciara
}
* [Talk to Pedia] -> comics

=== ciara ===
Hey, so does a demon named Ciara come around here often? #speaker:Noxie #portrait:default #player portrait:noxie_neutral #layout:left
Oh yes, the crow demon. She often checks out books from the fantasy section. #speaker:Pedia #layout:right
Oh ok. #speaker:Noxie #layout:left
...
Actually can I see some of those books?
~ ciara_reading = true
->END
=== comics ===
Wow you have a lot of books here.
->END