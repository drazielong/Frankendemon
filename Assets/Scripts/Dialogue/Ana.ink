INCLUDE Globals.ink
I heard you could move those plants down that path. #speaker:Noxie #layout:left #player portrait:noxie_neutral

Well, sure I can. #speaker:??? #layout:right #portrait:ana_neutral

Great, let’s go. #speaker:??? #layout:left

My name’s Ana. Like Anatomy, haha. #speaker:Ana #layout:right
I’m pretty clever for that one, huh?

Ok. Sure, I guess. #speaker:??? #layout:left

What’s your name? #speaker:Ana #layout:right

... #speaker:??? #layout:left
It doesn’t matter.
... #speaker:Ana #layout:right
... #speaker:??? #layout:left
I don’t really like it.

Didn’t you choose your name? #speaker:Ana #layout:right
You can just change it if you don’t like it.
It took me a couple of tries.

No, my parents gave it to me. #speaker:??? #layout:left

Then what do you wanna be called? #speaker:Ana #layout:right

I dunno #speaker:??? #layout:left
... #player portrait:noxie_thinking
...Noxie? #speaker:Noxie

Hmmm like noxious gas? #speaker:Ana #layout:right

No. #speaker:Noxie #layout:left #player portrait:noxie_neutral
That’s just what I name my characters in video games.

Huh? #speaker:Ana #layout:right

There’s no video games here, okay. #speaker:Noxie #layout:left
Anyway, let’s get going-

Sorry, but I’m a bit busy right now...#speaker:Ana #layout:right
How about if you help me, I’ll help you?

Uuuuugh #speaker:Noxie #layout:left
There’s always gotta be something in it for you huh?

Haha, I’m not trying to be mean. #speaker:Ana #layout:right
It’s just that, I’m kind of doing my job right now. If you could help me free up my work then I could help you! 

Whatever, just tell me what you want me to do. #speaker:Noxie #layout:left 
Thank you so much. #speaker:Ana #layout:right
My job is to create vessels for the souls to inhabit, and I’m trying to make something from the human world. 
I think it’s called an “elephant”?
But I don’t really know what it looks like.

Oh, is that it? #speaker:Noxie #layout:left
It’s easy. It’s huge and it has big ears and a trunk.

... #speaker:Ana #layout:right
... #speaker:Noxie #layout:left

I’m sorry, but I don’t think that description is, um, descriptive enough. #speaker:Ana #layout:right
Maybe if I could see a picture of it?

Oh I know just the place! #speaker:Dearil #layout:subleft #companion portrait:dearil_neutral

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
->END

=== hobbies ===
What do you like to do for fun? #speaker:Noxie #layout:left
Why are you asking me this. #speaker:Ciara #layout:right
To like... get to know you, right? #speaker:Noxie #layout:left
Look, I'm busy right now. #speaker:Ciara #layout:right
If it will satisfy you, I like to read.
Oh, okay. Read about what? #speaker:Noxie #layout:left
It doesn't matter. #speaker:Ciara #layout:right
Not like I'd expect you to understand anyway.
Er, okay sorry. I'll leave now. #speaker:Noxie #layout:left
I might understand you a bit better than you think... #portrait:invis
For now... I wonder if there's something around here that might help me connect with her.
~ ciara_met = true
->END

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