INCLUDE globals.ink
{Ciara_completed == true: -> helloagain}
//play after getting to the end of fantasy (no longer accessible)

Hello. #speaker:Ciara #portrait:default #layout:right
Hey, nice to meet ya! #speaker:Noxie #layout:left
Could you share your essence with me?
Um... that's a bit forward. #speaker:Ciara #layout:right
(Maybe I should try to get to know her first.) #speaker:Noxie #layout:left

* [Ask about what she's doing.] -> ask
* [Compliment her dress.] -> fantasy

=== ask ===
I'm tending to the flock, clearly. #speaker:Ciara #layout:right
The birds here can't defend themselves properly, so that's why I have to protect them.
In exchange, I can sell their eggs, I guess.
That's cool! #speaker:Noxie #layout:left
If you say so. #speaker:Ciara #layout:right
(She doesn't seem to want to talk more about this.) #speaker:Noxie #layout:left

-> END

=== fantasy ===
Cool dress! I like how the feathers stick out of it. It kinda reminds me of a witch dress! #speaker:Noxie #layout:left
You've read about them at the library as well? #speaker:Ciara #layout:right
Humans are so interesting. You know, they don't have powers like we do, so instead they make up stories about worlds where they do.
But even so, they take what they have already for granted. 
They write stories about having the power to fly, yet they have airplanes and technology that can take them even beyond the bounds of their world.
Maybe one day I'll make a trip to the Temperamental Domain and make a contract with one. I would love to meet them.
Actually... I was once a human! #speaker:Noxie #layout:left
Really? Then could you tell me? What makes you want to escape into fantasy? #speaker:Ciara #layout:right
I uh... I dunno how to answer that. #speaker:Noxie #layout:left
I don't really have any memories of my life as a human... but I kinda have some vague feelings about it.
To me, stories are just something fun and different to do, ya know?
...#speaker:Ciara #layout:right
I suppose you're right. I do the same thing as I engross myself in these stories myself.
I feel like there is more behind a creator's intentions, though. 
If I wrote something, it would probably just be about my life or something. #speaker:Noxie #layout:left
Hm... maybe that is part of it. #speaker:Ciara #layout:right
Could it be a way to communicate something that can't be put into simple terms?
Noxie, is it? Thank you for indulging in my ruminations. 
I wouldn't mind sharing my essence with you.
Really?! #speaker:Noxie #layout:left
It is my way of communicating something that can't be put into words. #speaker:Ciara #layout:right
When your memories return, I expect to hear more about the human world.

~ essence_name = "Ciara"
~ Ciara_completed = true
->END

=== helloagain ===
Have you checked out the library? #speaker:Ciara #layout:right
->END