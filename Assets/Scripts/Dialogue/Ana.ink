INCLUDE Globals.ink
{ana_completed == true: -> done}
{ana_help == true: -> help}
{ana_reading == true: -> reading}
{ana_met == true: -> met}

I heard you could move those plants down that path. #speaker:??? #layout:left #player portrait:noxie_neutral #portrait:ana_neutral

Well, hello. #speaker:??? #layout:right 
Nice to meet you, too.
My name’s Ana. #speaker:Ana
Like “Anatomy,” haha.

Uh, yeah. Ok. #speaker:??? #layout:left

What’s your name? #speaker:Ana #layout:right

Uh #speaker:??? #layout:left
It doesn’t matter.
It’s a dumb name.

Didn’t you choose your name? #speaker:Ana #layout:right
You can just change it again if you don’t like it.

No, my parents gave it to me. #speaker:??? #layout:left

Then... What do you wanna be called? #speaker:Ana #layout:right

Sheesh, I dunno... #speaker:??? #layout:left
...
......
...Let’s just go with Noxie. #speaker:Noxie

Hmmm, like noxious gas? #speaker:Ana #layout:right

No? #speaker:Noxie #layout:left
It’s just a reference to my gamertag.

Huh? #speaker:Ana #layout:right

There’s no video games here, okay. #speaker:Noxie #layout:left
Anyway, I need you to move these plants-

Sorry, but I’m a bit busy right now...#speaker:Ana #layout:right
I’m supposed to be making animal bodies right now, and to be honest, it isn’t my strong suit.
I’m much better at humanoid designs, but I have to start with animals first, apparently.
Anyway... I’ve already wasted so much time and material trying to make this one creature.
If I can’t get it right this time, I’m gonna be moved to another branch, and I really, really, wanna stay in this one.
How about if you help me, I’ll help you?

Uuuuugh #speaker:Noxie #layout:left
There’s always gotta be something in it for you huh?

What? #speaker:Ana #layout:right
It’s just that,

Whatever, just tell me what you want me to do. #speaker:Noxie #layout:left 

... Alright. #speaker:Ana #layout:right
So my job is to create vessels for the souls to inhabit, and I’m supposed to make something from the human world. 
I think it’s called an “elephant”?
But I don’t really know what it looks like.

Oh, is that it? #speaker:Noxie #layout:left
It’s easy. It’s huge and it has big ears and a trunk.

... #speaker:Ana #layout:right
... #speaker:Noxie #layout:left

I’m sorry, but I don’t think that description is, um, descriptive enough. #speaker:Ana #layout:right
Maybe if I could see a picture of it?

Why don't we go try the library? #speaker:Dearil #layout:subleft #companion portrait:dearil_neutral
~ ana_met = true
->END

=== met ===
I’d like to see a picture of an elephant, please. #speaker:Ana #layout:right #player portrait:noxie_neutral #portrait:ana_neutral
->END

=== reading ===
There’s a picture of an elephant in this. #speaker:Noxie #layout:left #player portrait:noxie_neutral #portrait:ana_neutral
Oh! #speaker:Ana #layout:right
Wow this is fascinating. 
This is perfect, thank you!
~ cutscene = true

Huh? That’s not an elephant. #speaker:Noxie #layout:left #player portrait:noxie_confused
~ cutscene = false

Thank you so much! #speaker:Ana #layout:right
I think I’m gonna keep reading this, there’s so many different creatures in here. 
When they see how good I am at this they’ll just be begging me to make demons!

Uh huh, I'm sure they will... #speaker:Noxie #layout:left #player portrait:noxie_sigh

How about I go help you with your problem now? #speaker:Ana #layout:right

~ tp = true
~ ana_help = true
->help

== help ===
Basically, soul plants are actually one big organism. #speaker:Ana #layout:right
If you know where it is, there’s a spot you can touch that makes them retract for a while.
~ cutscene = true

How come you know where it is? #speaker:Noxie #layout:left
~ cutscene = false

Well because I can see it! #speaker:Ana #layout:right

I can't see anything. #speaker:Noxie #layout:left

How about I show you, then? #speaker:Ana #layout:right
I have to go back to work, but I want to share something with you.
Take it as a token of my gratitude. 
~ tp = true

Good luck on your journey, Noxie.
(Ana returns to her job) #portrait:invis #player portrait:invis #layout:none

~ tp = false
~ essence_name = "Ana"
~ essence_activate = true
~ ana_completed = true
-> END

=== done === 
How's it going? #speaker:Ana #layout:right #player portrait:noxie_neutral #portrait:ana_neutral
Need help again?

Nope. Just passing through. #speaker:Noxie #layout:left

Oh just here to see me, huh. #speaker:Ana #layout:right
I'm flattered!

... #speaker:Noxie #layout:left #player portrait:noxie_sigh
->END
