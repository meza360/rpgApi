describe "Users";
describe "CharacterWeapon";
describe "Characters";
describe "Weapon";

SELECT U.*,C."Name",C."RpgClass",W."Name",W."Damage" FROM
"AspNetUsers" U
JOIN
"Characters" C
ON
U."Id" =C."UserId"
JOIN
"CharacterWeapon" CW
ON
CW."CharactersId" = C."Id"
JOIN
"Weapons" W
ON
W."Id" = CW."WeaponsId";

COMMIT;