INCLUDE globals.ink

//if u have raw essence skip
{has_rawEssence: -> essence}
Hello! Hi! Salutations! #speaker:Mortis #portrait:mortis_happy #layout:right
Look! I'm over here now! #layout:left
You've already started walking, so why don't we hurry along with the readjustment period? #layout:right
How are those relatively new limbs treating you?
+ ["Was I in an accident?"] -> dead
+ ["Who are you?"] -> who

=== dead ===
How you died I'm not certain of, but how you're here is my doing!
I caught your faint little human soul and reengineered it for a demon's body.
Truly fascinating stuff!
->cont

=== who ===
Curious about me?
Why, I'm Mortis, of course! The Decay Domain's leading scientist in the field of necromancy!
->cont

=== cont ===
It seems like your cognitive pathways are functional. Wonderful!
It's very likely that you do not retain any memories from your past life as of now, but this is perfectly natural!
Over time, you should start to recall your past, if my theories are correct. 
Now for the next part of my hypothesis, I need you to collect something called essences. They are a part of a demon's soul that in part forms their identity.
I've observed that demons are able to exchange their essences with each other at their leisure.
These essences are malleable and change as they're passed from person to person, like they are adapting to the new host in a way.
By infusing them into your soul, you physically adopt new characteristics such as powers and growths upon your body.
Typically a human soul should not be able to infuse a demon's essence, but you are special!
Not only because your soul has already been fused with a demon's body, but because your body is malleable as well.
{has_correctEssence: |Before I continue my incessant ramblings, why don't you try finding someone willing to share their essence with you? Come back to me when you when you have.}
->END

=== essence ===
I see you've found an essence from someone!#speaker:Mortis #portrait:mortis_happy #layout:right
As I suspected, you can't interact with it as demons normally would.
Allow me.
(Mortis inserts the essence into some kind of machine. It groans and creaks as it processes it.)
(Eventually it finishes the task and a glass tube opens up to reveal a pair of arms.)
Voila! I have made you a new pair of arms!
How did you do that???#speaker:Noxie #portrait:default #layout:left
As much as I would love to get into the details, I shall simplify it for you.#speaker:Mortis #portrait:mortis_happy  #layout:right
Very very verrry simply, I took that essence and infused it with the preserved limbs of a recently deceased. 
And now you should be able to detach those arms and equip these ones and use their power!
All thanks to my genuis.
~ has_rawEssence = false
~ has_correctEssence = true
->END