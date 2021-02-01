//Класс с настройками строк в соответствии с языком. Поддерживает функции StringSettings(int language). Позже заменит одинаковые переменные на одну
[System.Serializable]
public struct StringSettings
{
    public string headphones;           //"Для наилучшего погружения рекомендуем использовать наушники"
    public string playTutorial;        //"Пройти обучение"
    public string skipTutorial;        //"Пропустить обучение"
    public string pauseHeader;         //"Пауза"
    public string @continue;            //"Продолжить"
    public string restart;              //"Перезапустить"

    public string victoryHeader;       //"Победа"

    public string deathHeader;         //"Поражение"

    public string confirmationHeader;  //"Подвтерждение"
    public string confirmationYes;     //"Да"
    public string confirmationNo;      //"Нет"
    public string exit;                 //"Выход"

    public string bestScore;
    public string equipment;            //"Снаряжение"
    public string shop;                 //"Лавка"
    public string content;              //"Содержание"
    public string settings;             //"Настройки"
    public string graphicsLow;         //"Графика: низко"
    public string graphicsNormal;      //"Графика: нормально"
    public string volume;               //"Громкость"
    public string language;             //"Язык: "

    public string next;                 //"Далее"
    public string previous;             //"Предыдущий
    public string following;            //"Следующий"
    public string back;                 //"Назад"
    public string select;               //"Выбрать"
    public string purchase;             //"Купить"
    public string currentWeapon;       //"Текущее оружие"
    public string currentArmor;        //"Текущая броян"
    public string currentTalisman;     //"Текущий талисман"

    public string longsword;            //"Длинный меч"
    public string brokenSword;         //"Сломанный меч"
    public string falchion;             //"Фальшион"
    public string zweichender;          //"Двуручный меч"
    public string peterSword;          //"Меч Петра"
    public string januariusDagger;     //"Кинжал Януария"
    public string spear;                //"Венское копье"
    public string russianSword;        //"Меч, покрытый елеем"

    public string longswordDescription;        //Описание длинного меча
    public string brokenSwordDescription;     //Описание сломанного меча
    public string falchionDescription;         //Описание фальшиона
    public string zweichenderDescription;      //Описание двуручного меча
    public string peterSwordDescription;      //Описание меча Петра
    public string januariusDaggerDescription; //Описание кинжала Януария
    public string spearDescription;            //Описание Венсого копья
    public string russianSwordDescription;    //Описание меча, покрытого елеем

    public string longswordLoadingScreenDescription;         //Описание длинного меча на загрузочном экране
    public string brokenSwordLoadingScreenDescription;      //Описание сломанного меча на загрузочном экране
    public string falchionLoadingScreenDescription;          //Описание фальшиона на загрузочном экране
    public string zweichenderLoadingScreenDescription;       //Описание двуручного меча на загрузочном экране
    public string peterSwordLoadingScreenDescription;       //Описание меча Петра на загрузочном экране
    public string januariusDaggerLoadingScreenDescription;  //Описание кинжала Януария на загрузочном экране
    public string spearLoadingScreenDescription;             //Описание Венсого копья на загрузочном экране
    public string russianSwordLoadingScreenDescription;     //Описание меча, покрытого елеем на загрузочном экране

    public string lightArmor;                                  //"Легкая броня"
    public string chainMail;                                   //"Кольчуга"
    public string strengthenedChainMail;                      //"Укрепленная кольчуга"
    public string heavyArmor;                                  //"Тяжелый доспех"

    public string lightArmorDescription;                      //Описание легкой брони
    public string chainMailDescription;                       //Описание кольчуги
    public string strengthenedChainMailDescription;          //Описание усиленной кольчуги
    public string heavyArmorDescription;                      //Описание тяжелого доспеха

    public string lightArmorLoadingScreenDescription;       //Описание легкой брони на загрузочном экране
    public string chainMailLoadingScreenDescription;        //Описание кольчуги на загрузочном экране
    public string strengthenedChainMailLoadingScreenDescription;   //Описание усиленной кольчуги на загрузочном экране
    public string heavyArmorLoadingScreenDescription;       //Описание тяжелого доспеха на загрузочном экране

    public string noCharm;                                     //"Талисман не выбран"
    public string welfareCharm;                                 //"Талисман благоденствия"
    public string hereticCharm;                               //"Талисман еретика"
    public string orderCharm;                                 //"Талисман ордена"
    public string crucifix;                                     //"Нагрудный крест"
    public string ivoryPommel;                                 //"Навершие из слоновой кости"
    public string popeSeal;                                   //"Печать папы"
    public string traitorPendant;                             //"Подвеска предателя"

    public string welfareCharmDescription;                     //Описание талисмана благоденствия
    public string hereticCharmDescription;                   //Описание талисмана еретика
    public string orderCharmDescription;                     //Описание талисмана ордена
    public string crucifixDescription;                         //Описание нагрудного креста
    public string ivoryPommelDescription;                     //Описание навершия из слоновой кости
    public string popeSealDescription;                       //Описание печати папы
    public string traitorPendantDescription;                 //Описание подвески предателя

    public string welfareCharmLoadingScreenDescription;      //Описание талисмана благоденствия на загрузочном экране
    public string hereticCharmLoadingScreenDescription;    //Описание талисмана еретика на загрузочном экране
    public string orderCharmLoadingScreenDescription;      //Описание талисмана ордена на загрузочном экране
    public string crucifixLoadingScreenDescription;          //Описание нагрудного креста на загрузочном экране
    public string ivoryPommelLoadingScreenDescription;      //Описание навершия из слоновой кости на загрузочном экране
    public string popeSealLoadingScreenDescription;        //Описание печати папы на загрузочном экране
    public string traitorPendantLoadingScreenDescription;  //Описание подвески предателя на загрузочном экране

    public string prologue;     //"Пролог"
    public string epilogue;     //"Эпилог"
    public string titles;       //"Титры"
    public string chapter1;    //"Глава 1"
    public string chapter2;    //"Глава 2"
    public string chapter3;    //"Глава 3"
    public string chapter4;    //"Глава 4"
    public string chapter5;    //"Глава 5"
    public string chapter6;    //"Глава 6"
    public string chapter7;    //"Глава 7"
    public string chapter8;    //"Глава 8"
    public string chapter9;    //"Глава 9"
    public string chapter10;   //"Глава 10"
    public string chapter11;   //"Глава 11"

    public string popUpNowAvailable;
    public string popUpSizeUpdate;
    public string popUpNewCombo;
    public string popUpOk;

    public string tutorialPoints;
    public string tutorialCombometer;
    public string tutorialAttack;
    public string tutorialEnemy;
    public string tutorialExit;
    public string tutorialEnd;

    //Конструктор всех строк в соответсвии с языком
    public StringSettings(int language)
    //Выбор языка. 0 - английский, 1 - русский, 2 - немецкий, 3 - французский, 4 - эсперанто.
    {
        switch (language)
        {
            case 0: //Английский
                headphones = "We recommend using headphones for the best gaming experience";
                playTutorial = "Start Tutorial";
                skipTutorial = "Skip Tutorial";
                pauseHeader = "Pause";
                @continue = "Continue";
                restart = "Restart";

                victoryHeader = "Victory!";

                deathHeader = "Defeat";

                exit = "Exit";
                confirmationHeader = "Are you sure?";
                confirmationYes = "Yes";
                confirmationNo = "No";

                bestScore = "Best score:";
                equipment = "Equipment";
                shop = "Shop";
                content = "Content";
                settings = "Settings";
                next = "Next";
                back = "Back";
                previous = "Previous";
                following = "Next";       
                select = "Select";
                purchase = "Purchase";
                currentWeapon = "Weapon: ";
                currentArmor = "Armor: ";
                currentTalisman = "Talisman: ";
                graphicsLow = "Graphics: low";
                graphicsNormal = "Graphics: normal";
                volume = "Volume: ";
                this.language = "Language: English";

                longsword = "Longsword";
                brokenSword = "Broken sword";
                falchion = "Falchion";
                zweichender = "Templar's Zweichander";
                peterSword = "Sword of Peter";
                januariusDagger = "Dagger of Saint Januarius's blood";
                spear = "Holy Lance";
                russianSword = "Covered in oil sword";

                longswordDescription = "The best sword for protracted battles and yard skirmishes. Allows you to strike enemies with a powerful blow of a two-handed grip, and to bring death with one hand, while protecting yourself with the other.";
                brokenSwordDescription = "I can't believe anyone was dumb enough to use a broken sword! He's completely useless! Using it in battle is suicide.";
                falchionDescription = "It is difficult to deliver stabbing blowswith it, and in order to break through someone's defense, you need to put your hand far behind your head. If you exchange it for a bowl of soup, then it will bring more benefits.";
                zweichenderDescription = "Their time is coming to an end, just like the time of the knights. Soon neither one nor the other will be left, and in their place come people without honor and faith in the Lord.";
                peterSwordDescription = "They say that with such a sword one of the apostles cut off the ear of a slave. Apparently, the apostle did not have enough skill to kill a man.";
                januariusDaggerDescription = "I can feel it burning in my hands. A good sign for a magic talisman, but will it be handy during a serious battle?";
                spearDescription = "Having previously served as a weapon in the murder of the son of the Lord, now this spear finds a new purpose.";
                russianSwordDescription = "An elegant solution for rough weapons. However, I still can't get used to the idea that I have to use the weapons of the Slavs.";

                longswordLoadingScreenDescription = "The long sword, aka Romanesque, aka Capetian, aka bastard sword – is the most popular weapon of warriors from Europe during the High Middle Ages.\nIt was most in demand among knights and warriors of the princes of Russia due to its flexibility in use.\nDespite its impressive size and fearsome appearance, such weapons are often used as a secondary, if not only intimidating opponents.";
                brokenSwordLoadingScreenDescription = "Every person who is at least somewhat versed in war knows that a sword was a matter of special pride for a warrior, and wearing it often meant belonging to a high military rank.\n Also, do not dismiss the fact of kinship between a veteran of battles and his loyal blade - and sword become the comrade too difficult to give up even after his " +'"' + "death" + '"' + ".\nSo it happened with this sword.";
                falchionLoadingScreenDescription = "Falchion is European-handed weapon with expanding the end of the blade, perfectly suited for chopping and crushing blows.\nIn Christianity, one curious episode is associated with him described in the Gospel of John, during which the apostle Peter, who was trying to resist, cut off the ear of a high priestly servant named Malchus.\nTherefore, this weapon is also known as " + '"' + "Malchus" + '"' + ".";
                zweichenderLoadingScreenDescription = "This weapon has, like all other two-handed swords, an impressive and wid blade.\n It allows you to make powerful blows, which makes every swing truly deadly.\n However, only the strongest and most skilled warriors can use it.\nDue to its properties, the two-handed arm was popular within Templar, who used it throughout their existence.";
                peterSwordLoadingScreenDescription = "A short one-handed sword, according to legend, belonged to one of the apostles of Christ.\nIts inconveniently displaced center of mass, the curved guard and the already worn-out inscription on the pommel speaks more of a low-quality forgery than of a sacred relic.";
                januariusDaggerLoadingScreenDescription = "According to legend, this exquisite dagger was forged from an alloy of steel, stained with the blood of the great martyr Januarius.\nThis saint is known for the fact that twice he saved himself and his companions from death in a miraculous way: firstly from the merciless heat of the furnace, and then from the sharp fangs of wild animals.\nWho knows, maybe the blade will be able to give its owner the same luck, or even reward of unnaturally long life.";
                spearLoadingScreenDescription = "Holy Lance is one of the most important Christian artifacts, closely related to the Passion of Christ.\nAccording to legend, it belonged to the Roman centurion Longinus, who struck the crucified prophet right in the heart without damaging his bones. This" + '"' + "blow of mercy" + '"' + "endowed the weapon with holiness, which allowed it to become not only the greatest relic of Christianity, but also the strongest manifestation of the power of the Lord in this world.";
                russianSwordLoadingScreenDescription = "Surprisingly, how sometimes things can appear in some unexpected places. This blade, once forged in Russia, made its way across all of Europe and took part in a variety of battles. But even for the greatest warrior the century of battles passes, and the time of oblivion comes.\nBut sometimes happens that new life is breathed into the old weapon, just like the veteran finds another calling. Will the flame of his being burn down to ashes? Or will it light the way to the future?";

                lightArmor = "Light Armor";                                  
                chainMail = "Chain Mail";                                   
                strengthenedChainMail = "Strengthened Chain Mail";                      
                heavyArmor = "Heavy Armor";                                  

                lightArmorDescription = "Basic armor. The elements of the armor are worn out, and even it seems to be a props. However, what else to expect from an armor that has endured a journey across the world?";                      
                chainMailDescription = "The most common knightly armor. It is a ring woven together into a single fabric. Protects the entire body.";                       
                strengthenedChainMailDescription = "An improved version of the chain mail. This is manifested in a tighter fit of the rings and an increase in their number. In addition, the sub-armor does not smell of rust anymore!";         
                heavyArmorDescription = "Most powerful armor set. Significantly increases the chances of getting out of the battle without injuries incompatible with life.\nAlso has the ability to make its owner more brutal.";                       

                lightArmorLoadingScreenDescription = "A pair of bracers, a simple breastplate, helmet and rags - and the best set of armor for the crook is ready. On the battlefield, such a warrior stands out from the crowd and seems an easy target.\nHowever, under the visor can hide both a poor man - an adventurer and a seasoned veteran, ready to teach a couple of lessons to overly arrogant opponents.\nAnd the light weight of the armor does not hinder movement, allowing with ease to strike and parry blows.";        
                chainMailLoadingScreenDescription = "Ring armor - armor woven from iron rings, a metal net to protect against blows from an ax, sword or dagger. There are several varieties of this armor, from short shirts that cover only the chest and abdomen, to real skin, which protects the whole body except the face and arms to the elbows.\nEasy to make and to repair (holes in chain mail can be patched with a new piece of chain mail).";        
                strengthenedChainMailLoadingScreenDescription = "In contrast to conventional chain mail, mounted version of it is made of stronger alloys with several times more snugly rings to each other, allowing you to stop not only strikes the blades, but also the boom.\nAn additional layer of protection is also provided by a thickened linen-based underarmor.";   
                heavyArmorLoadingScreenDescription = "Warriors are very different by nature. For some, agility, speed and maneuverability are important. Others prefer to shower their enemies with arrows from a nearby hill.\nBut there are those who want to feel like a doomsday weapon. Dressed in heavy composite armor, with a huge sword at the ready, they bite into the enemy formation and leave no one alive there. For such people, heavy armor exists.";

                noCharm = "Not selected";
                welfareCharm = "Welfare charm";
                hereticCharm = "Heretic's charm";
                orderCharm = "Order's charm";
                crucifix = "Crucifix";
                ivoryPommel = "Ivory pommel";
                popeSeal = "Pope's seal";
                traitorPendant = "Traitor's pendant";

                welfareCharmDescription = "A wooden statuette in the shape of an old wise man immersed in deep thoughts. Every man from the village receives it at the age of eighteenth. Wearing it gives the wearer ability to hit harder.";
                hereticCharmDescription = "A mysterious power from the mountain has giving this amulet to those who were in danger from the church. After this" + '"' + "reward" + '"' +", person becomes weaker due to constant fear, but his increased wariness make him also more tenacious. After the death of the owner, amulet disappears.";
                orderCharmDescription = "One of the most common things in the Holy Order of Conservation. Issued to every recruit at the initiation ceremony. Since, during its heyday, service to the order was a great honor, all bearers of the talisman became stronger in spirit.";
                crucifixDescription = "Monastic cross worn by all the clergy in the Holy Order of the Preservation. Thanks to their strong faith in God, backed up by this little thing, the monks fought fiercely to the last. However, their blows were weak.";
                ivoryPommelDescription = "According to legend, it belonged to the pommel first Grand Master of the Order — Emzsore. There were also legends about his vanity: a bunch of scribes, under threat of death, described his entire life in great detail.";
                popeSealDescription = "In the last centuries, all the destinies of the world are decided by one person. Pope. This man knows everything, he calmly sends thousands of people to the war for the sacred land. It is no wonder that the one wearing its seal also knows a little more about the world than an ordinary person.";
                traitorPendantDescription = "The traitor's pendant is a kind of gesture from the side of the Holy Order of Preservation towards those who have failed its statutes. A person wearing such a thing is a soul doomed to torment, in the illusory hope of redeeming them. But this path gives incredible opportunities.";

                welfareCharmLoadingScreenDescription = "A simple charm that looks like roughly carved from wood ridiculous person, that you will not want to put it on yourself. However, not everything is so simple.\nAccording to the beliefs of local residents, this and similar charms bring the owner good luck, happiness and save him from an accidental arrow. Perhaps this is just superstition, but one thing is for sure: the charm adds confidence in owner's attack.";
                hereticCharmLoadingScreenDescription = "Another curious artifact of local residents. During the reign of the church over the village, many of its inhabitants were tortured and persecuted by crusaders and monks.\nThe talisman had the role of a secret instruction from an unknown force from the top of Unheimberg, so the churchmen would not suspect anything and made it possible to escape and hide.";
                orderCharmLoadingScreenDescription = "One of the most common artifacts in the Holy Order of Preservation, it was given to each knight after the initiation ceremony.\nThis thing meant that the neophyte would be faithful to the order until the end of his days and perform any deed in His glory. Even if this act would mean death.\nMany also believed that the Lord was protecting them as his chosen ones.";
                crucifixLoadingScreenDescription = "Another relic of the Holy Order of the Conservation. It is widespread in the monastic part of the order. It is a small cross, a symbolic copy of the one on which Jesus was crucified.\nThere are two methods of wearing the cross: lay people wear it under their clothes, while church officials and knights can wear it over it.\nThe cross gives confidence in divine truth.";
                ivoryPommelLoadingScreenDescription = "Tops called the top of any products, including the handle of a blade, staff, and so on, or structures (a tower or dome).\nSpeaking of an ivory pommel, it means the handle of a sword, otherwise you would not be able to fight .\nAccording to legend, it belonged to the first Grand Master of Order — Emzore.";
                popeSealLoadingScreenDescription = "The Pope's Seal, or the Fisherman's Ring, is one of the most curious artifacts of the Vatican Court. The ring depicts the Apostle Peter in the role of a fisherman casting a fishing net from a boat into the sea.\nThis is due to the fact that in worldly life Peter was a fisherman, and also with the words of Jesus that his disciples would become fishers of human souls. Most likely an imitation.";
                traitorPendantLoadingScreenDescription = "Artifact of the Holy Order of Conservation. It is a medallion depicting a mourner in a hood, over which a crown of thorns is worn.\nOn the one hand it symbolizes the deep sorrow for the soul of a traitor and makes him a calling for atonement of sins martyr on the other hand, .\nWearing is associated with incredible suffering.";

                prologue = "Prologue: Arrival";
                epilogue = "Epilogue";
                titles = "Titles";
                chapter1 = "Chapter 1: Village";
                chapter2 = "Chapter 2: Assault";
                chapter3 = "Chapter 3: Escape";
                chapter4 = "Chapter 4: Memories";
                chapter5 = "Chapter 5: Defenders";
                chapter6 = "Chapter 6: Confrontation";
                chapter7 = "Chapter 7: Ent";
                chapter8 = "Chapter 8: Burial";
                chapter9 = "Chapter 9: Laboratories";
                chapter10 = "Chapter 10: Throne";
                chapter11 = "Chapter 11: Necromancer";

                popUpNowAvailable = "Now available";
                popUpSizeUpdate = "Attack storage increased to";
                popUpNewCombo = ". New combos are available.";
                popUpOk = "OK";

                tutorialPoints = "To catch a point, touch screen on the area that the point follows when point is on the white line. Catch three points.";
                tutorialCombometer = "When you catch four dots of the same color, Sebastian's weapon will light up in flames, and he will be ready to strike. Light knight's sword.";
                tutorialAttack = "When the weapon is on fire, knight can attack. Move your opponent's portrait to the left for a normal (green) attack, and to the right for a heavy (red) attack.";
                tutorialEnemy = "Every point you missed counts towards the enemy. The enemy will immediately attack knight if they collect enough points. Defeat him before he kills Sebastian.";
                tutorialExit = "You get ink, for killing opponents, which you can spend on purchasing weapons or the next Chapters of Silly Hope.\nNow press the back button on your device to open the menu and exit.";
                tutorialEnd = "Start the adventure";
                break;

            case 1: //Русский
                headphones = "Для наилучшего погружения рекомендуем использовать наушники";
                playTutorial = "Начать обучение";
                skipTutorial = "Пропустить обучение";
                pauseHeader = "Пауза";
                @continue = "Продолжить";
                restart = "Перезапустить";

                victoryHeader = "Победа!";

                deathHeader = "Поражение";

                exit = "Выход";
                confirmationHeader = "Вы уверены?";
                confirmationYes = "Да";
                confirmationNo = "Нет";

                bestScore = "Лучший счет:";
                equipment = "Снаряжение";
                shop = "Лавка";
                content = "Содержание";
                settings = "Настройки";
                next = "Далее";
                back = "Назад";
                previous = "Предыдущее";
                following = "Следующее";
                select = "Выбрать";
                purchase = "Купить";
                currentWeapon = "Оружие: ";
                currentArmor = "Броня ";
                currentTalisman = "Талисман ";
                graphicsLow = "Графика: низко";
                graphicsNormal = "Графика: нормально";
                volume = "Громкость:";
                this.language = "Язык: Русский";

                longsword = "Длинный меч";
                brokenSword = "Сломанный меч";
                falchion = "Фальшион";
                zweichender = "Двуручный меч ордена Тамплиеров";
                peterSword = "Меч святого Петра";
                januariusDagger = "Кинжал из крови Святого Януария";
                spear = "Венское копьё";
                russianSword = "Меч, покрытый елеем";

                longswordDescription = "Лучший меч для затяжных сражений и дворовых стычек. Позволяет и разить врагов мощным ударом двуручного хвата, и нести смерть одной рукой, пока защищаешь себя другой.";
                brokenSwordDescription = "Не могу поверить, что у кого-то хватило ума использовать сломанный меч! Он же совершенно бесполезен! Использовать его в бою – самоубийство.";
                falchionDescription = "Им трудно наносить колющие удары, а чтобы пробиться через чью-то защиту, нужно заносить руку аж за голову. Если поменять на тарелку супа, то пользы он принесет больше.";
                zweichenderDescription = "Их время подходит к концу, как и время рыцарей. Скоро ни тех, ни других не останется, а на их место придут люди без чести и веры в Господа.";
                peterSwordDescription = "Говорят, что таким мечом один из апостолов отрубил какому-то рабу ухо. Видимо, мастерства на то, чтобы убить человека у апостола не хватило.";
                januariusDaggerDescription = "Я чувствую, как он пылает в моих руках. Хороший знак для магического талисмана, но будет ли он удобен во время серьезной битвы?";
                spearDescription = "Cлужившее ранее орудием убийства сына Господа, сейчас это копье находит новое назначение. Неудивительно, что им также приходится убивать.";
                russianSwordDescription = "Элегантное решение для грубого оружия. Однако я всё не могу свыкнуться с мыслью о том, что мне приходится использовать оружие славян.";

                longswordLoadingScreenDescription = "Длинный меч, он же романский, он же капетингский, он же рыцарский – самое популярное оружие воинов из Европы периода Высокого Средневековья.\nПользовался наибольшим спросом у рыцарей и  дружинников князей Руси за счет гибкости в использовании.\nНесмотря на свой внушительный размер и грозный вид, подобное оружие часто использовалось в качестве вспомогательного, а то и вовсе лишь устрашающего противников.";
                brokenSwordLoadingScreenDescription = "Каждому хоть сколь-нибудь сведущему в войне человеку известно что меч для воина являлся предметом особой гордости, а его ношение нередко означало принадлежность к высокому роду или военному чину.\nТакже не стоит отметать и факт почти родственной близости между прошедшим годы битв ветераном и его верным клинком — от боевого товарища сложно отказаться даже после его «смерти».\nТак произошло и с этим мечом.";
                falchionLoadingScreenDescription = "Фальшион это европейское одноручное оружие с расширяющимся к концу клинком, прекрасно подходящее для рубящих и дробящих ударов. В христианстве с ним связан один любопытный эпизод: дело в том, что в описанном в евангелии от Иоанна эпизоде взятия Христа под стражу, во время которого пытавшийся оказать сопротивление апостол Пётр отсёк ухо первосвященническому рабу по имени Малх.\nПоэтому это оружие также известно под названием «Малхус».";
                zweichenderLoadingScreenDescription = "Это оружие имеет, как и все прочие двуручные мечи, внушительных размеров клинок, который, однако, выгодно отличается более широким лезвием. Эта деталь позволяет совершать мощные удары, отчего каждый взмах им становится поистине смертоносным. Однако использовать его могут лишь самые сильные и умелые воины.\nБлагодаря своим свойствам двуручник был популярен у ордена тамплиеров, которые пользовались им все время своего существования.";
                peterSwordLoadingScreenDescription = "Короткий одноручный меч, по легенде принадлежавший одному из апостолов Христа.\n Его неудобно смещенный центр масс, кривая гарда и уже стершаяся надпись на навершии говорит скорее о низкокачественной подделке, чем о священной реликвии.";
                januariusDaggerLoadingScreenDescription = "По легенде этот изысканный кинжал был выкован из сплава стали, обагренной кровью великомученика и епископа Януария. Этот святой известен тем, что дважды спасал себя и своих соратников от гибели чудесным образом: сначала от беспощадного жара печи, а потом и от острых клыков диких зверей. Кто знает, может, клинок сможет подарить своему обладателю такую же удачу, или вовсе наградит неестественно долгой жизнью.";
                spearLoadingScreenDescription = "Венское копьё или копьё Лонгина — один из важнейших христианских артефактов, тесно связанный с Орудиями Страстей Христовых.\nПо легендам оно принадлежало римскому центуриону Лонгину, поразившему распятого пророка прямо в сердце не повредив костей.Этот" + '"' + "удар милосердия" + '"' + "наделил оружие святостью, позволившей ему стать не только величайшей реликвией христианства, но и сильнейшим проявлением силы Господа в этом мире.";
                russianSwordLoadingScreenDescription = "Удивительно, в каких неожиданных местах порой могут находиться вещи. Этот некогда выкованный на Руси клинок  проделал путь через всю Европу и поучаствовал в самых разных сражениях. Но, как и с любым, даже самым великим воином, век сражений проходит, и наступает время забвения.\nНо случается и так, что в старое оружие вдыхают новую жизнь, как и ветеран находит иное призвание.Спалит ли пламя бытия его дотла? Или осветит дорогу в будущее?";

                lightArmor = "Легкая броня";
                chainMail = "Кольчуга";
                strengthenedChainMail = "Укрепленная кольчуга";
                heavyArmor = "Тяжелый доспех";

                lightArmorDescription = "Базовая броня. Элементы доспеха изношенные, а сам он отдает бутафорией. Однако, чего еще ожидать от брони, перенесшей путешествие через весь мир?";
                chainMailDescription = "Самый распространенный рыцарский поддоспешник. Представляет из себя кольца, сплетенные между собой в единое полотно. Защищает весь корпус.";
                strengthenedChainMailDescription = "Улучшенный вариант кольчуги. Это проявляется в более плотном прилегании колец и увеличении их количества. Помимо этого, поддоспешник теперь не пахнет ржавчиной!";
                heavyArmorDescription = "Самый мощный комплект брони. Значительно повышает шансы выйти из боя без увечий несовместимых с жизнью.\nТакже обладает свойством делать своего владельца в несколько раз брутальнее.";

                lightArmorLoadingScreenDescription = "Пара нарукавников, простецкий нагрудник, шлем и тряпье – и лучший комплект брони для проходимца готов. На поле боя такой воин выделяется из толпы и кажется легкой мишенью.\nОднако под забралом может скрываться как бедняк - искатель приключений, так и закаленный ветеран, готовый преподать пару уроков чересчур заносчивым противникам.\nДа и малый вес доспеха не сковывает движения, позволяя с легкостью наносить и парировать удары.";
                chainMailLoadingScreenDescription = "Кольчатый доспех — доспех, сплетённый из железных колец, металлическая сеть для защиты от ударов топора, меча или кинжала. Существует несколько разновидностей этой брони, от коротких рубах, покрывающих лишь грудь и живот, до настоящей шкуры, защищающей все тело кроме лица и рук до локтей.\nПростая и в изготовлении, и в ремонте(дыры в кольчуге можно латать новым куском кольчуги) она завоевала почет во всем цивилизованном мире.";
                strengthenedChainMailLoadingScreenDescription = "В отличие от обычной кольчуги, укрепленный ее вариант изготавливается из более прочных сплавов с в несколько раз более плотным прилеганием колец друг к другу, что позволяет останавливать не только удары клинков, но и стрелы.\nДополнительный уровень защиты обеспечивает также утолщенный поддоспешник, изготавливаемый на основе льняной ткани.";
                heavyArmorLoadingScreenDescription = "Воины по своей натуре бывают самые разные. Одним важна ловкость, скорость и маневренность. Другие предпочитают поливать врагов градом стрел с ближайшего холма.\nНо есть и такие, кому хочется почувствовать себя орудием судного дня. Облаченные в тяжелый композитный доспех, с огромным мечом наперевес, они вгрызаются во вражеское построение и не оставляют там никого в живых.Для таких людей и существует тяжелый доспех.";

                noCharm = "Не выбран";                                     
                welfareCharm = "Талисман благоденствия";   
                hereticCharm = "Талисман еретика";                               
                orderCharm = "Талисман ордена";                                 
                crucifix = "Нагрудный крест";                                    
                ivoryPommel = "Навершие из слоновой кости"; 
                popeSeal = "Печать папы";                                  
                traitorPendant = "Подвеска предателя";

                welfareCharmDescription = "Деревянная статуэтка в виде умудренного годами старца, погруженного в глубокие раздумья. Каждый муж из деревни получает его на восемнадцатый год от роду. Его ношение придает владельцу уверенности и делает удар крепче.";                     
                hereticCharmDescription = "Таинственная сила с вершины горы награждала им тех, кому угрожала опасность от церкви. В результате человек становится слабее из-за постоянного страха, однако его повышенная осторожность дает ему возможность стать более живучим. После смерти владельца исчезает.";                   
                orderCharmDescription = "Одна из самых распространенных вещей в Святом ордене Сохранения. Выдается каждому новобранцу на церемонии посвящения. Поскольку, во времена своего расцвета, служба ордену была великой честью, все носители талисмана становились сильнее духом. Похоже, это действует и сейчас.";                     
                crucifixDescription = "Монашеский крест, который носили все священнослужители в Святом ордене Сохранения. Благодаря своей сильной вере в Бога, подкрепленной этой вещицей, монахи дрались ожесточенно и до последнего. Однако и удары их были слабы.";                         
                ivoryPommelDescription = "По легенде, это навершие принадлежало первому гранд-магистру ордена Эмцоре. Также ходили легенды и о его тщеславии: куча писарей под угрозой смерти описывали весь его жизненный путь в мельчайших подробностях.";                     
                popeSealDescription = "Последние столетия все судьбы мира решает один человек. Папа Римский. Этому человеку ведомо все, он спокойно направляет тысячи людей на войну за священную землю. Немудрено, что носящий его печать, тоже знает о мире чуть больше, чем обычный человек.";                       
                traitorPendantDescription = "Подвеска предателя это своеобразный жест со стороны Святого ордена Сохранения в сторону тех, кто подвел его уставы. Носящий такую вещь человек есть душа обреченная на муки, в призрачной надежде их искупить. Но этот путь дарует невероятные возможности.";                 

                welfareCharmLoadingScreenDescription = "Простецкий талисман, похожий на нелепого человека, грубо вырезанного из дерева, на первый взгляд, не вызывает желания надеть его на себя. Однако не все так просто.\nСогласно поверьям местных жителей, этот и подобные ему талисманы приносят владельцу удачу, счастье и спасают от случайной стрелы. Может быть, это всего лишь суеверия, но одно можно сказать точно: уверенности в своем ударе талисман прибавляет.";      
                hereticCharmLoadingScreenDescription = "Еще один любопытный артефакт местных жителей.  Во время властвования церкви над деревней, многие ее жители подвергались истязаниям и гонениям со стороны крестоносцев, а позднее и монахов.\nТалисман здесь имел роль тайного указания от неизвестной силы с вершины Унхаймберга, чтобы церковники ничего не заподозрили и давал возможность сбежать и затаиться.";    
                orderCharmLoadingScreenDescription = "Один из самых распространенных в Святом ордене Сохранения артефакт, выдавался каждому рыцарю после церемонии посвящения.\nТакая вещь означала, что неофит будет верен ордену до конца дней своих и совершит любое деяние во славу его. Даже если это деяние будет означать смерть.\nМногие также верили, что Господь защищает их, как своих избранников.";      
                crucifixLoadingScreenDescription = "Еще одна реликвия Святого ордена Сохранения, распространенная, прежде всего, в монашеской части ордена. Представляет собой небольшой крест, символическую копию того, на котором был распят Иисус.\nЕсть два метода ношения креста: мирские жители носят его под одеждой, в то время как служители церкви и рыцари могут носить поверх нее.\nКрест придает уверенности в Божественной истине.";          
                ivoryPommelLoadingScreenDescription = "Навершиями называются верхушки каких-либо изделий, в том числе рукоятки клинка, посоха и так далее, либо сооружения (терема или купола).\nГоворя о навершии из слоновой кости, имеется ввиду именно рукоятка меча, в противном случае, Вы бы не смогли сражаться.\nПо легенде принадлежала первому гранд - магистру ордена Эмцоре.";      
                popeSealLoadingScreenDescription = "Печать папы, или Кольцо рыбака – является одним из самых любопытных артефактов Ватиканского двора. На кольце изображен апостол Петр в роли рыбака, а именно забрасывающим рыбацкую сеть с лодки в море. \nЭто связано с тем, что в мирской жизни Петр был рыбаком, а также со словами Иисуса о том, что его ученики станут ловцами человеческих душ.Вероятнее всего подделка.";       
                traitorPendantLoadingScreenDescription = "Артефакт Святого ордена Сохранения. Представляет собой медальон с изображением плакальщицы в капюшоне, поверх которого надет терновый венок.\nЭто символизирует с одной стороны глубокую скорбь ордена по душе предателя, а с другой стороны делает из него мученика, призывая искупить грехи.\nНошение сопряжено с невероятными страданиями."; 

                prologue = "Пролог: Прибытие";
                epilogue = "Эпилог";
                titles = "Титры";
                chapter1 = "Глава 1: Деревня";
                chapter2 = "Глава 2: Нападение";
                chapter3 = "Глава 3: Бегство";
                chapter4 = "Глава 4: Воспоминания";
                chapter5 = "Глава 5: Защитники";
                chapter6 = "Глава 6: Противостояние";
                chapter7 = "Глава 7: Энт";
                chapter8 = "Глава 8: Могильник";
                chapter9 = "Глава 9: Лаборатории";
                chapter10 = "Глава 10: Трон";
                chapter11 = "Глава 11: Некромант";

                popUpNowAvailable = "Теперь доступно:";
                popUpSizeUpdate = "Лимит запасаемых атак увеличен до";
                popUpNewCombo = ". Новые комбинации атак доступны.";
                popUpOk = "Хорошо";

                tutorialPoints = "Чтобы поймать точку, нажмите на область экрана, по которой точка следует, когда она окажется на белой линии. Поймайте три точки.";
                tutorialCombometer = "Когда вы поймаете 4 точки одного цвета, оружие Себастьяна загорится пламенем, а он сам будет готов нанести удар. Зажгите меч Себастьяна.";
                tutorialAttack = "Когда оружие загорится, вы сможете атаковать. Передвиньте портрет противника влево, чтобы нанести обычную (зеленую) атаку, и вправо, чтобы нанести тяжелую (красную) атаку.";
                tutorialEnemy = "Каждая пропущенная вами точка идет в счет врага. Противник незамедлительно вас атакует, если соберет достаточно точек. Победите его до того, как он убъет Себастьяна.";
                tutorialExit = "За убийство противников вы получаете чернила, которые сможете потратить на приобретение оружия или следующих Глав Silly Hope.\n Теперь нажмите кнопку Назад (back) на вашем устройстве, чтобы открыть меню и выйти.";
                tutorialEnd = "Начать приключение";
                break;

            case 2: //Немецкий
                headphones = "Wir empfehlen die Verwendung von Kopfhörern für das beste Spielerlebnis";
                playTutorial = "Starten Tutorial";
                skipTutorial = "Überspringen Tutorial";
                pauseHeader = "Pause";
                @continue = "Fortsetzen";
                restart = "Neustart";

                victoryHeader = "Victoria!";

                deathHeader = "Niederlage";

                exit = "Herauskommen";
                confirmationHeader = "Sie sind zuversichtlich?";
                confirmationYes = "Ja";
                confirmationNo = "Nein";

                bestScore = "Bestes Ergebnis:";
                equipment = "Ausrüstung";
                shop = "Verkaufsstelle";
                content = "Inhalt";
                settings = "Justage";
                next = "Nächsten";
                back = "Zurück";
                previous = "Bisherige";
                following = "Folgende";
                select = "Wählen";
                purchase = "Kauf";
                currentWeapon = "Waffen: ";
                currentArmor = "Rüstung: ";
                currentTalisman = "Amulett";
                graphicsLow = "Graphik: niedrig";
                graphicsNormal = "Graphik: fein";
                volume = "Volumen:";
                this.language = "Sprache: Deutsch";

                longsword = "Langes Schwert";
                brokenSword = "Zerbrochenes Schwert";
                falchion = "Falchion";
                zweichender = "Zweihänder";
                peterSword = "Malchus";
                januariusDagger = "Dolch aus Blut von Januarius";
                spear = "Heilige Lanze";
                russianSword = "Schwert in Öl";

                longswordDescription = "Das beste Schwert für langwierige Schlachten und Scharmützel. Ermöglicht es Ihnen, Feinde mit einem kräftigen Schlag eines Zweihandgriffs zu schlagen und mit einer Hand den Tod zu bringen, während Sie sich mit der anderen schützen.";
                brokenSwordDescription = "Ich kann nicht glauben, dass jemand dumm genug war, ein zerbrochenes Schwert zu benutzen! Er ist völlig nutzlos! Es im Kampf einzusetzen ist Selbstmord.";
                falchionDescription = "Es ist schwierig, damit stechende Schläge auszuführen, und um die Verteidigung von jemandem zu durchbrechen, müssen Sie Ihre Hand weit hinter Ihren Kopf legen. Wenn Sie es gegen eine Schüssel Suppe eintauschen, bringt es mehr Vorteile.";
                zweichenderDescription = "Ihre Zeit geht zu Ende, genau wie die Zeit der Ritter. Bald werden weder der eine noch der andere übrig sein, und an ihre Stelle treten Menschen ohne Ehre und Glauben an den Herrn.";
                peterSwordDescription = "Sie sagen, dass einer der Apostel mit einem solchen Schwert einem Sklaven das Ohr abgeschnitten hat. Anscheinend hatte der Apostel nicht genug Fähigkeiten, um einen Mann zu töten.";
                januariusDaggerDescription = "Ich kann es in meinen Händen brennen fühlen. Ein gutes Zeichen für einen magischen Talisman, aber wird es in einem ernsthaften Kampf nützlich sein?";
                spearDescription = "Nachdem dieser Speer zuvor als Waffe bei der Ermordung des Sohnes des Herrn gedient hatte, findet er jetzt einen neuen Zweck.";
                russianSwordDescription = "Eine elegante Lösung für grobe Waffen. Ich kann mich jedoch immer noch nicht daran gewöhnen, dass ich die Waffen der Slawen benutzen muss.";

                longswordLoadingScreenDescription = "Das Langschwert, alias romanisch, alias Capetian, alias Bastardschwert, ist im Hochmittelalter die beliebteste Waffe von Kriegern aus Europa.\nEs war bei Rittern und Kriegern der Fürsten Russlands aufgrund seiner Flexibilität im Einsatz am gefragtesten Trotz ihrer beeindruckenden Größe und ihres furchterregenden Aussehens werden solche Waffen oft als sekundäre, wenn nicht nur einschüchternde Gegner eingesetzt.";
                brokenSwordLoadingScreenDescription = "Jeder, der sich zumindest ein wenig mit Krieg auskennt, weiß, dass ein Schwert für einen Krieger ein besonderer Stolz war, und das Tragen bedeutete oft, zu einem hohen militärischen Rang zu gehören. \n Entlassen Sie auch nicht die Tatsache der Verwandtschaft zwischen einem Veteranen von Schlachten und seiner treuen Klinge - und Schwert werden der Kamerad zu schwierig, um auch nach seinem " + '"' + "Tod" + '"' + " aufzugeben. \nSo geschah es mit diesem Schwert.";
                falchionLoadingScreenDescription = "Falchion ist eine Waffe mit europäischer Hand, die das Ende der Klinge erweitert und sich perfekt zum Hacken und Quetschen von Schlägen eignet. Im Christentum wird eine merkwürdige Episode mit ihm in Verbindung gebracht, die im Johannesevangelium beschrieben wird, während der der Apostel Petrus dies versuchte widerstehen, einem hochpriesterlichen Diener namens Malchus das Ohr abschneiden. \nDaher wird diese Waffe auch als " + '"' + "Malchus" + '"' + " bekannt.";
                zweichenderLoadingScreenDescription = "Diese Waffe hat wie alle anderen Zweihandschwerter eine beeindruckende und breite Klinge. \nSie ermöglicht es Ihnen, mächtige Schläge auszuführen, was jeden Schlag wirklich tödlich macht. \nAllerdings können nur die stärksten und geschicktesten Krieger sie verwenden. \n Aufgrund seiner Eigenschaften war der Zweihandarm bei Templern beliebt, die ihn während ihrer gesamten Existenz verwendeten.";
                peterSwordLoadingScreenDescription = "Ein kurzes Einhandschwert gehörte der Legende nach einem der Apostel Christi. Sein ungünstig verschobener Schwerpunkt, die gebogene Wache und die bereits abgenutzte Inschrift auf dem Knauf sprechen eher für eine Fälschung von geringer Qualität als eines heiligen Relikts.";
                januariusDaggerLoadingScreenDescription = "Der Legende nach wurde dieser exquisite Dolch aus einer Stahllegierung geschmiedet, die mit dem Blut des großen Märtyrers Januarius befleckt war. \nDieser Heilige ist dafür bekannt, dass er sich und seine Gefährten zweimal auf wundersame Weise vor dem Tod gerettet hat: erstens aus die gnadenlose Hitze des Ofens und dann von den scharfen Zähnen wilder Tiere. \nWer weiß, vielleicht kann die Klinge ihrem Besitzer das gleiche Glück geben oder sogar eine unnatürlich lange Lebensdauer belohnen.";
                spearLoadingScreenDescription = "Die Heilige Lanze ist eines der wichtigsten christlichen Artefakte, das eng mit der Passion Christi verbunden ist. Der Legende nach gehörte sie dem römischen Zenturio Longinus, der den gekreuzigten Propheten mitten ins Herz schlug, ohne seine Knochen zu beschädigen. Dieser " + '"' + "Schlag der Barmherzigkeit" + '"' + " verlieh der Waffe Heiligkeit, die es ihr ermöglichte, nicht nur das größte Relikt des Christentums zu werden, sondern auch die stärkste Manifestation der Kraft des Herrn in dieser Welt.";
                russianSwordLoadingScreenDescription = "Überraschenderweise, wie manchmal Dinge an unerwarteten Orten auftreten können. Diese Klinge, einst in Russland geschmiedet, gelangte durch ganz Europa und nahm an verschiedenen Schlachten teil. Aber selbst für den größten Krieger vergeht das Jahrhundert der Schlachten und die Zeit des Vergessens kommt. Aber manchmal passiert es, dass der alten Waffe neues Leben eingehaucht wird, genau wie der Veteran eine andere Berufung findet. Wird die Flamme seines Seins zu Asche niederbrennen? Oder wird es den Weg in die Zukunft weisen?";

                lightArmor = "Leichte Rüstung";
                chainMail = "Kettenhemd";
                strengthenedChainMail = "Verstärktes Kettenhemd";
                heavyArmor = "Schwere Rüstung";

                lightArmorDescription = "Grundlegende Rüstung. Die Elemente der Rüstung sind abgenutzt, und selbst es scheint sich um eine Requisite zu handeln. Was kann man sonst noch von einer Rüstung erwarten, die eine Reise um die Welt überstanden hat?";
                chainMailDescription = "Die häufigste Ritterrüstung. Es ist ein Ring, der zu einem einzigen Stoff zusammengewebt ist. Schützt den gesamten Körper.";
                strengthenedChainMailDescription = "Eine verbesserte Version des Kettenhemdes. Dies äußert sich in einem engeren Sitz der Ringe und einer Erhöhung ihrer Anzahl. Außerdem riecht die Unterpanzerung nicht mehr nach Rost!";
                heavyArmorDescription = "Stärkstes Rüstungsset. Erhöht die Chancen, ohne lebensunverträgliche Verletzungen aus dem Kampf auszusteigen, erheblich. \nAAuch die Fähigkeit, seinen Besitzer brutaler zu machen.";

                lightArmorLoadingScreenDescription = "Ein Paar Armschienen, ein einfacher Brustpanzer, ein Helm und Lumpen - und die beste Rüstung für den Gauner ist fertig. Auf dem Schlachtfeld hebt sich ein solcher Krieger von der Masse ab und scheint ein leichtes Ziel zu sein.\nJedoch unter dem Visier kann sowohl einen armen Mann als auch einen Abenteurer und einen erfahrenen Veteranen verstecken, der bereit ist, übermäßig arroganten Gegnern ein paar Lektionen beizubringen.\nUnd das geringe Gewicht der Rüstung behindert die Bewegung nicht und ermöglicht es, mit Leichtigkeit zu schlagen und Schläge abzuwehren.";
                chainMailLoadingScreenDescription = "Ringpanzerung - Rüstung aus Eisenringen, ein Metallnetz zum Schutz vor Schlägen von Axt, Schwert oder Dolch. Es gibt verschiedene Arten dieser Rüstung, von kurzen Hemden, die nur Brust und Bauch bedecken, bis hin zu echter Haut, die den gesamten Körper mit Ausnahme von Gesicht und Armen bis zu den Ellbogen schützt mit einem neuen Stück Kettenhemd gepatcht werden).";
                strengthenedChainMailLoadingScreenDescription = "Im Gegensatz zu herkömmlichen Kettenhemden besteht die montierte Version aus stärkeren Legierungen mit um ein Vielfaches engeren Ringen, sodass Sie nicht nur die Klingen, sondern auch den Ausleger stoppen können.\nAeine zusätzliche Schutzschicht ist ebenfalls vorhanden durch eine verdickte Unterrüstung auf Leinenbasis.";
                heavyArmorLoadingScreenDescription = "Krieger sind von Natur aus sehr unterschiedlich. Für einige sind Beweglichkeit, Geschwindigkeit und Manövrierfähigkeit wichtig. Andere ziehen es vor, ihre Feinde mit Pfeilen von einem nahe gelegenen Hügel zu überschütten.\nDAber es gibt diejenigen, die sich wie eine Weltuntergangswaffe fühlen wollen. In schwerer zusammengesetzter Rüstung mit einem riesigen Schwert im Anschlag beißen sie in die feindliche Formation und lassen dort niemanden am Leben. Für solche Menschen gibt es schwere Rüstungen.";

                noCharm = "Kein ausgewählt";
                welfareCharm = "Wohlfahrtsamulette";
                hereticCharm = "Ketzer Amulette";
                orderCharm = "Amulette der Ordnung";
                crucifix = "Kruzifix";
                ivoryPommel = "Elfenbeinknauf";
                popeSeal = "Papstsiegel";
                traitorPendant = "Verräter Anhänger";

                welfareCharmDescription = "Eine hölzerne Statuette in Form eines alten weisen Mannes, der in tiefe Gedanken versunken ist. Jeder Mann aus dem Dorf erhält sie im Alter von achtzehn Jahren. Wenn er sie trägt, kann der Träger härter schlagen.";
                hereticCharmDescription = "Eine mysteriöse Kraft vom Berg hat dieses Amulett denen gegeben, die von der Kirche in Gefahr waren. Nach diesem " + '"' + "Belohnung" + '"' + " wird der Mensch aufgrund ständiger Angst schwächer, aber seine erhöhte Vorsicht macht ihn auch zäher. Nach dem Tod des Besitzers verschwindet das Amulett.";
                orderCharmDescription = "Eines der häufigsten Dinge in der Heiligen Ordnung der Erhaltung. Wird jedem Rekruten bei der Initiationszeremonie ausgestellt. Da der Dienst am Orden in seiner Blütezeit eine große Ehre war, wurden alle Träger des Talismans geistig stärker.";
                crucifixDescription = "Klosterkreuz, das von allen Geistlichen im Heiligen Orden der Bewahrung getragen wird. Dank ihres starken Glaubens an Gott, unterstützt von diesem kleinen Ding, kämpften die Mönche bis zuletzt heftig. Ihre Schläge waren jedoch schwach.";
                ivoryPommelDescription = "Der Legende nach gehörte es dem ersten Großmeister des Ordens - Emzsore. Es gab auch Legenden über seine Eitelkeit: Eine Gruppe von Schriftgelehrten, die vom Tod bedroht waren, beschrieb sein ganzes Leben sehr detailliert.";
                popeSealDescription = "In den letzten Jahrhunderten wurden alle Schicksale der Welt von einer Person bestimmt. Papst. Dieser Mann weiß alles, er schickt ruhig Tausende von Menschen in den Krieg um das heilige Land. Es ist kein Wunder, dass derjenige, der sein Siegel trägt, auch ein bisschen mehr über die Welt weiß als ein gewöhnlicher Mensch.";
                traitorPendantDescription = "Der Anhänger des Verräters ist eine Art Geste von der Seite des Heiligen Ordens der Bewahrung gegenüber denen, die seine Statuten enttäuscht haben. Eine Person, die so etwas trägt, ist eine Seele, die zur Qual verurteilt ist, in der illusorischen Hoffnung, sie zu erlösen. Aber dieser Weg bietet unglaubliche Möglichkeiten.";

                welfareCharmLoadingScreenDescription = "Ein einfacher Zauber, der aussieht wie grob aus Holz geschnitzte lächerliche Person, die Sie nicht auf sich selbst legen wollen. Allerdings ist nicht alles so einfach.\nNach den Überzeugungen der Anwohner bringen dieser und ähnliche Reize dem Besitzer Glück, Glück und retten ihn vor einem versehentlichen Pfeil. Vielleicht ist dies nur Aberglaube, aber eines ist sicher: Der Charme erhöht das Vertrauen in den Angriff des Besitzers.";
                hereticCharmLoadingScreenDescription = "Ein weiteres merkwürdiges Artefakt der Anwohner. Während der Regierungszeit der Kirche über dem Dorf wurden viele ihrer Bewohner von den Kreuzfahrern und später von den Mönchen gefoltert und verfolgt.\nDer Talisman hier hatte die Rolle einer geheimen Anweisung einer unbekannten Truppe von der Spitze Unheimbergs, so dass die Kirchenmänner nichts ahnen und ihnen die Möglichkeit geben würden, zu fliehen und sich zu verstecken.";
                orderCharmLoadingScreenDescription = "Als eines der häufigsten Artefakte im Heiligen Orden der Bewahrung wurde es jedem Ritter nach der Initiationszeremonie gegeben. Dies bedeutete, dass der Neuling dem Befehl bis zum Ende seiner Tage treu bleiben und jede Tat in seiner Herrlichkeit vollbringen würde. Selbst wenn diese Tat den Tod bedeuten würde. Viele glaubten auch, dass der Herr sie als seine Auserwählten beschützte.";
                crucifixLoadingScreenDescription = "Ein weiteres Relikt des Heiligen Ordens der Erhaltung. Es ist im klösterlichen Teil des Ordens weit verbreitet. Es ist ein kleines Kreuz, eine symbolische Kopie des Kreuzes, auf dem Jesus gekreuzigt wurde. Es gibt zwei Methoden, das Kreuz zu tragen: Laien tragen es unter ihrer Kleidung, während Kirchenbeamte und Ritter es darüber tragen können. Das Kreuz gibt Vertrauen in die göttliche Wahrheit.";
                ivoryPommelLoadingScreenDescription = "Tops werden als die Oberseite eines Produkts bezeichnet, einschließlich des Griffs einer Klinge, eines Stabes usw. oder von Strukturen (eines Turms oder einer Kuppel).\nSDas Sprechen eines Elfenbeinknaufs bedeutet den Griff eines Schwertes, sonst wären Sie es nicht fähig zu kämpfen.\nDer Legende nach gehörte es dem ersten Großmeister der Ordnung - Emzore.";
                popeSealLoadingScreenDescription = "Das Siegel des Papstes oder der Fischerring ist eines der merkwürdigsten Artefakte des vatikanischen Hofes. Der Ring zeigt den Apostel Petrus in der Rolle eines Fischers, der ein Fischernetz von einem Boot ins Meer wirft. Dies ist auf die Tatsache zurückzuführen, dass Petrus im weltlichen Leben ein Fischer war, und auch auf die Worte Jesu, die seine Jünger tun würden werde Fischer menschlicher Seelen. Höchstwahrscheinlich eine Nachahmung.";
                traitorPendantLoadingScreenDescription = "Artefakt des Heiligen Ordens der Erhaltung. Es ist ein Medaillon, das einen Trauernden in einer Kapuze darstellt, über der eine Dornenkrone getragen wird. Einerseits symbolisiert es die tiefe Trauer um die Seele eines Verräters und macht ihn andererseits zu einem Aufruf zur Sühne des Märtyrers der Sünden Tragen ist mit unglaublichem Leiden verbunden.";

                prologue = "Prolog: Ankunft";
                epilogue = "Epilog";
                titles = "Credits";
                chapter1 = "Kapitel 1: Dorf";
                chapter2 = "Kapitel 2: Angriff";
                chapter3 = "Kapitel 3: Flucht";
                chapter4 = "Kapitel 4: Erinnerungen";
                chapter5 = "Kapitel 5: Verteidiger";
                chapter6 = "Kapitel 6: Konfrontation";
                chapter7 = "Kapitel 7: Ent";
                chapter8 = "Kapitel 8: Beerdigung";
                chapter9 = "Kapitel 9: Laboratorien";
                chapter10 = "Kapitel 10: Thron";
                chapter11 = "Kapitel 11: Nekromant";

                popUpNowAvailable = "Jetzt verfügbar";
                popUpSizeUpdate = "Angriffsspeicherlimit auf";
                popUpNewCombo = "erhöht. Neue Combos sind verfügbar.";
                popUpOk = "OK";

                tutorialPoints = "Um einen Punkt zu erfassen, berühren Sie den Bereich, dem der Punkt folgt, wenn sich der Punkt auf der weißen Linie befindet. Fange drei Punkte.";
                tutorialCombometer = "Wenn Sie vier Punkte derselben Farbe fangen, leuchtet Sebastians Waffe in Flammen auf und er ist bereit zu schlagen. Leichtes Ritterschwert.";
                tutorialAttack = "Wenn die Waffe in Flammen steht, kann der Ritter angreifen. Bewegen Sie das Porträt Ihres Gegners für einen normalen (grünen) Angriff nach links und für einen schweren (roten) Angriff nach rechts.";
                tutorialEnemy = "Jeder Punkt, den Sie verpasst haben, zählt für den Feind. Der Feind greift den Ritter sofort an, wenn er genügend Punkte gesammelt hat. Besiege ihn, bevor er Sebastian tötet.";
                tutorialExit = "Sie erhalten Tinte, um Gegner zu töten, die Sie für den Kauf von Waffen oder die nächsten Kapitel der dummen Hoffnung ausgeben können.\nDrücken Sie nun die Zurück-Taste auf Ihrem Gerät, um das Menü zu öffnen und zu beenden.";
                tutorialEnd = "Starte das Abenteuer";
                break;

            case 3: //Французский
                headphones = "Nous vous recommandons d'utiliser des écouteurs pour la meilleure expérience de jeu";
                playTutorial = "Commencer le tutoriel";
                skipTutorial = "Sauter le tutoriel";
                pauseHeader = "Pause";
                @continue = "Continuer";
                restart = "Redémarrer";

                victoryHeader = "Victoire!";

                deathHeader = "Défaite";

                exit = "Sortir";
                confirmationHeader = "Vous etes sûr?";
                confirmationYes = "Oui";
                confirmationNo = "Non";

                bestScore = "Meilleur score:";
                equipment = "Équipement";
                shop = "Magasin";
                content = "Сontenu";
                settings = "Configuration";
                next = "Ensuit";
                back = "Retour";
                previous = "Précédent";
                following = "Suivant";
                currentWeapon = "Armes: ";
                currentArmor = "Armure: ";
                currentTalisman = "Fétiche: ";
                select = "Select";
                purchase = "Acheter";
                graphicsLow = "Graphique: faible";
                graphicsNormal = "Graphique: bien";
                volume = "Volume:";
                this.language = "Langue: Français";

                longsword = "Épée bâtarde";
                brokenSword = "Épée cassée";
                falchion = "Fauchon";
                zweichender = "L'espadon";
                peterSword = "Épée de saint Pierre";
                januariusDagger = "Dague de sang de saint Januarius";
                spear = "Sainte Lance";
                russianSword = "Couvert d'épée à l'huile";

                longswordDescription = "La meilleure épée pour les batailles prolongées et les escarmouches de chantier. Vous permet de frapper les ennemis d'un coup puissant d'une prise à deux mains, et d'apporter la mort d'une main, tout en vous protégeant de l'autre.";
                brokenSwordDescription = "Je ne peux pas croire que quiconque ait été assez stupide pour utiliser une épée cassée! Il est complètement inutile! L'utiliser au combat est un suicide.";
                falchionDescription = "Il est difficile de lui donner des coups de couteau, et pour percer la défense de quelqu'un, vous devez mettre votre main loin derrière votre tête. Si vous l'échangez contre un bol de soupe, cela apportera plus d'avantages.";
                zweichenderDescription = "Leur temps touche à sa fin, tout comme le temps des chevaliers. Bientôt, ni l'un ni l'autre ne seront laissés, et à leur place viendront des gens sans honneur et sans foi au Seigneur.";
                peterSwordDescription = "Ils disent qu'avec une telle épée, l'un des apôtres a coupé l'oreille d'un esclave. Apparemment, l'apôtre n'avait pas assez de talent pour tuer un homme.";
                januariusDaggerDescription = "Je peux sentir le brûler dans mes mains. Un bon signe pour un talisman magique, mais sera-t-il utile lors d'une bataille sérieuse?";
                spearDescription = "Ayant auparavant servi d'arme dans le meurtre du fils du Seigneur, cette lance trouve maintenant un nouveau but.";
                russianSwordDescription = "Une solution élégante pour les armes brutes. Cependant, je n'arrive toujours pas à m'habituer à l'idée que je dois utiliser les armes des Slaves.";

                longswordLoadingScreenDescription = "La longue épée, alias romane, alias capétienne, alias épée bâtarde - est l'arme la plus populaire des guerriers d'Europe au haut Moyen Âge.\nElle était la plus demandée par les chevaliers et les guerriers des princes de Russie en raison de sa flexibilité d'utilisation.\nMalgré sa taille impressionnante et son apparence redoutable, ces armes sont souvent utilisées comme adversaires secondaires, voire intimidants.";
                brokenSwordLoadingScreenDescription = "Toute personne au moins un peu versée dans la guerre sait qu'une épée était une question de fierté particulière pour un guerrier, et la porter signifiait souvent appartenir à un grade militaire élevé.\nDe plus, ne rejetez pas le fait de la parenté entre un vétéran de batailles et sa lame fidèle - et son épée deviennent le camarade trop difficile à abandonner même après sa "+ '"' + "mort" + '"' +".\nC'est arrivé avec cette épée.";
                falchionLoadingScreenDescription = "Fauchion est une arme de main européenne avec l'expansion de l'extrémité de la lame, parfaitement adaptée pour couper et écraser les coups. \nDans le christianisme, un épisode curieux lui est associé décrit dans l'Évangile de Jean, au cours duquel l'apôtre Pierre, qui essayait de résiste, coupe l'oreille d'un grand serviteur sacerdotal nommé Malchus.\nPar conséquent, cette arme est également connue sous le nom de " + '"' + "Malchus" + '"' + ".";
                zweichenderLoadingScreenDescription = "Cette arme a une lame impressionnante et large, comme toutes les autres épées à deux mains. \n Elle vous permet de faire des coups puissants, ce qui rend chaque coup vraiment mortel.\nCependant, seuls les guerriers les plus forts et les plus habiles peuvent l'utiliser.\nEn raison de ses propriétés, le bras à deux mains était populaire chez les Templiers, qui l'ont utilisé tout au long de leur existence.";
                peterSwordLoadingScreenDescription = "Une épée courte à une main, selon la légende, appartenait à l'un des apôtres du Christ.\nSon centre de masse déplacé de manière gênante, la garde incurvée et l'inscription déjà usée sur le pommeau parlent plus d'une contrefaçon de mauvaise qualité que d'une relique sacrée.";
                januariusDaggerLoadingScreenDescription = "Selon la légende, ce poignard exquis a été forgé à partir d'un alliage d'acier, taché du sang du grand martyr Januarius.\nCe saint est connu pour le fait qu'il s'est sauvé à deux reprises lui-même et ses compagnons de la mort d'une manière miraculeuse: d'abord de la chaleur impitoyable du four, puis des crocs acérés des animaux sauvages.\nQui sait, peut-être que la lame pourra donner à son propriétaire la même chance, voire la récompense d'une durée de vie anormalement longue.";
                spearLoadingScreenDescription = "Sainte Lance est l'un des artefacts chrétiens les plus importants, étroitement lié à la Passion du Christ.\nSelon la légende, il appartenait au centurion romain Longinus, qui frappa le prophète crucifié en plein cœur sans endommager ses os. Ce " + '"' + "coup de miséricorde" + '"' + " a doté l'arme de sainteté, ce qui lui a permis de devenir non seulement la plus grande relique du christianisme, mais aussi la manifestation la plus forte de la puissance du Seigneur en ce monde.";
                russianSwordLoadingScreenDescription = "Étonnamment, comment parfois les choses peuvent apparaître dans des endroits inattendus. Cette lame, autrefois forgée en Russie, a traversé toute l'Europe et a participé à diverses batailles. Mais même pour le plus grand guerrier, le siècle des batailles passe et le temps de l'oubli arrive.\nMais il arrive parfois qu'une nouvelle vie soit insufflée à l'ancienne arme, tout comme le vétéran trouve une autre vocation. La flamme de son être se réduira-t-elle en cendres? Ou éclairera-t-il la voie vers le futur?";

                lightArmor = "Armure légère";
                chainMail = "Cotte de mailles";
                strengthenedChainMail = "Cotte de mailles renforcée";
                heavyArmor = "Armure lourde";

                lightArmorDescription = "Armure de base. Les éléments de l'armure sont usés, et même cela semble être un accessoire. Cependant, à quoi s'attendre d'autre d'une armure qui a subi un voyage à travers le monde?";
                chainMailDescription = "L'armure chevaleresque la plus courante. C'est un anneau tissé ensemble en un seul tissu. Protège tout le corps.";
                strengthenedChainMailDescription = "Une version améliorée de la cotte de mailles. Cela se manifeste par un ajustement plus serré des anneaux et une augmentation de leur nombre. De plus, la sous-armure ne sent plus la rouille!";
                heavyArmorDescription = "Ensemble d'armure le plus puissant. Augmente considérablement les chances de sortir de la bataille sans blessures incompatibles avec la vie.\nA également la capacité de rendre son propriétaire plus brutal.";

                lightArmorLoadingScreenDescription = "Une paire de brassards, une simple cuirasse, un casque et des chiffons - et le meilleur ensemble d'armure pour l'escroc est prêt. Sur le champ de bataille, un tel guerrier se démarque de la foule et semble être une cible facile.\nCependant, sous la visière peut se cacher à la fois un pauvre homme - un aventurier et un vétéran aguerri, prêt à enseigner quelques leçons à des adversaires trop arrogants.\nEt le poids léger de l'armure n'empêche pas le mouvement, permettant de frapper et de parer facilement les coups.";
                chainMailLoadingScreenDescription = "Armure annulaire - armure tissée à partir d'anneaux de fer, un filet métallique pour se protéger des coups de hache, d'épée ou de poignard. Il existe plusieurs variétés de cette armure, des chemises courtes qui ne couvrent que la poitrine et l'abdomen, à la vraie peau, qui protège tout le corps sauf le visage et les bras jusqu'aux coudes.\nFacile à faire et à réparer (les trous dans la cotte de mailles peuvent être patché avec un nouveau morceau de cotte de mailles).";
                strengthenedChainMailLoadingScreenDescription = "Contrairement à la cotte de mailles conventionnelle, sa version montée est faite d'alliages plus solides avec des anneaux plusieurs fois plus serrés les uns aux autres, ce qui vous permet d'arrêter non seulement les coups des lames, mais aussi la flèche.\nUne couche de protection supplémentaire est également fournie par une aisselle épaissie à base de lin.";
                heavyArmorLoadingScreenDescription = "Les guerriers sont de nature très différente. Pour certains, l'agilité, la vitesse et la maniabilité sont importantes. D'autres préfèrent arroser leurs ennemis avec des flèches d'une colline voisine.\nMais il y a ceux qui veulent se sentir comme une arme apocalyptique. Vêtus d'une lourde armure composite, avec une énorme épée à portée de main, ils mordent dans la formation ennemie et ne laissent personne en vie. Pour de telles personnes, une armure lourde existe.";

                noCharm = "Aucun sélectionné";
                welfareCharm = "Fétiche de bien-être";
                hereticCharm = "Fétiche de l'hérétique";
                orderCharm = "Fétiche de l'Ordre";
                crucifix = "Crucifix";
                ivoryPommel = "Pommeau ivoire";
                popeSeal = "Sceau du pape";
                traitorPendant = "Pendentif de traître";

                welfareCharmDescription = "Une statuette en bois en forme de vieux sage plongé dans des pensées profondes. Tout homme du village le reçoit à l'âge de dix-huit ans. Le porter donne au porteur la capacité de frapper plus fort.";
                hereticCharmDescription = "Une puissance mystérieuse de la montagne a donné cette amulette à ceux qui étaient en danger de l'église. Après cette " + '"' + "récompense" + '"' + ", la personne devient plus faible en raison d'une peur constante, mais sa méfiance accrue le rend également plus tenace. Après la mort du propriétaire, l'amulette disparaît.";
                orderCharmDescription = "Une des choses les plus courantes dans le Saint Ordre de la Conservation. Délivré à chaque recrue lors de la cérémonie d'initiation. Puisque, à son apogée, le service à l'ordre était un grand honneur, tous les porteurs du talisman sont devenus plus forts en esprit.";
                crucifixDescription = "Croix monastique portée par tout le clergé du Saint Ordre de la Préservation. Grâce à leur forte foi en Dieu, soutenue par cette petite chose, les moines se sont battus férocement jusqu'au bout. Cependant, leurs coups étaient faibles.";
                ivoryPommelDescription = "Selon la légende, il appartenait au premier pommeau Grand Maître de l'Ordre - Emzsore. Il y avait aussi des légendes sur sa vanité: une bande de scribes, sous la menace de mort, décrivait sa vie entière en détail.";
                popeSealDescription = "Au cours des derniers siècles, toutes les destinées du monde sont décidées par une seule personne. Le pape. Cet homme sait tout, il envoie calmement des milliers de personnes à la guerre pour la terre sacrée. Il n'est pas étonnant que celui qui porte son sceau en sache aussi un peu plus sur le monde qu'une personne ordinaire.";
                traitorPendantDescription = "Le pendentif du traître est une sorte de geste du côté du Saint Ordre de Conservation envers ceux qui ont failli à ses statuts. Une personne portant une telle chose est une âme vouée au tourment, dans l'espoir illusoire de les racheter. Mais ce chemin offre des opportunités incroyables.";

                welfareCharmLoadingScreenDescription = "Un charme simple qui ressemble à peu près à une personne ridicule en bois, que vous ne voudrez pas mettre sur vous-même. Cependant, tout n'est pas si simple.\nSelon les croyances des résidents locaux, ce charme et des charmes similaires apportent au propriétaire chance, bonheur et le sauvent d'une flèche accidentelle. Ce n'est peut-être que de la superstition, mais une chose est sûre: le charme ajoute de la confiance dans l'attaque du propriétaire.";
                hereticCharmLoadingScreenDescription = "Un autre artefact curieux de résidents locaux. Pendant le règne de l'église sur le village, beaucoup de ses habitants ont été torturés et persécutés par les croisés, puis par les moines.\nLe talisman avait ici le rôle d'une instruction secrète d'une force inconnue du haut de l'Unheimberg, de sorte que les hommes d'église ne soupçonneraient rien et leur donneraient l'occasion de s'échapper et de se cacher.";
                orderCharmLoadingScreenDescription = "L'un des artefacts les plus courants de l'Ordre sacré de la préservation, il a été donné à chaque chevalier après la cérémonie d'initiation.\nCette chose signifiait que le néophyte serait fidèle à l'ordre jusqu'à la fin de ses jours et accomplirait tout acte dans sa gloire . Même si cet acte signifiait la mort.\nBeaucoup croyaient aussi que le Seigneur les protégeait en tant que ses élus.";
                crucifixLoadingScreenDescription = "Une autre relique du Saint Ordre de la Conservation. Il est répandu dans la partie monastique de l'ordre. C'est une petite croix, une copie symbolique de celle sur laquelle Jésus a été crucifié.\nIl existe deux méthodes pour porter la croix: les laïcs la portent sous leurs vêtements, tandis que les fonctionnaires de l'église et les chevaliers peuvent la porter par-dessus.\nLa croix donne confiance en la vérité divine.";
                ivoryPommelLoadingScreenDescription = "Hauts appelés le haut de tous les produits, y compris le manche d'une lame, un bâton, etc., ou des structures (une tour ou un dôme).\nParlant d'un pommeau en ivoire, cela signifie le manche d'une épée, sinon vous ne seriez pas capable de se battre.\nSelon la légende, il appartenait au premier Grand Maître de l'Ordre - Emzore.";
                popeSealLoadingScreenDescription = "Le sceau du pape, ou l'anneau du pêcheur, est l'un des artefacts les plus curieux de la Cour du Vatican. L'anneau représente l'apôtre Pierre dans le rôle d'un pêcheur lançant un filet de pêche depuis un bateau dans la mer.\nCela est dû au fait que dans la vie mondaine, Pierre était un pêcheur, et aussi avec les paroles de Jésus que ses disciples allaient devenir des pêcheurs d'âmes humaines. Très probablement une imitation.";
                traitorPendantLoadingScreenDescription = "Artefact du Saint Ordre de la Conservation. C'est un médaillon représentant une personne en deuil dans une cagoule, sur laquelle est portée une couronne d'épines.\nD'une part, il symbolise la profonde douleur pour l'âme d'un traître et fait de lui un appel à l'expiation des péchés martyr d'autre part.\nLe port est associé à une souffrance incroyable.";

                prologue = "Prologue: Arrivée";
                epilogue = "Épilogue";
                titles = "Crédits";
                chapter1 = "Chapitre 1: Village";
                chapter2 = "Chapitre 2: Assaut";
                chapter3 = "Chapitre 3: S'échapper";
                chapter4 = "Chapitre 4: Souvenirs";
                chapter5 = "Chapitre 5: Défenseurs";
                chapter6 = "Chapitre 6: Confrontation";
                chapter7 = "Chapitre 7: Ent";
                chapter8 = "Chapitre 8: Enterrement";
                chapter9 = "Chapitre 9: Laboratoires";
                chapter10 = "Chapitre 10: Trône";
                chapter11 = "Chapitre 11: Nécromancien";

                popUpNowAvailable = "Maintenant disponible";
                popUpSizeUpdate = "Limite de stockage d'attaque augmentée à";
                popUpNewCombo = ". De nouveaux combos sont disponibles.";
                popUpOk = "D'accord";

                tutorialPoints = "Pour capturer un point, touchez l'écran sur la zone que le point suit lorsque le point est sur la ligne blanche. Attrapez trois points.";
                tutorialCombometer = "Lorsque vous attrapez quatre points de la même couleur, l'arme de Sebastian s'allumera en flammes et il sera prêt à frapper. Épée de chevalier léger.";
                tutorialAttack = "Lorsque l'arme est en feu, le chevalier peut attaquer. Déplacez le portrait de votre adversaire vers la gauche pour une attaque normale (verte) et vers la droite pour une attaque lourde (rouge).";
                tutorialEnemy = "Chaque point que vous avez manqué compte pour l'ennemi. L'ennemi attaquera immédiatement le chevalier s'il accumule suffisamment de points. Battez-le avant qu'il ne tue Sebastian.";
                tutorialExit = "Vous obtenez de l'encre, pour tuer des adversaires, que vous pouvez dépenser pour acheter des armes ou les prochains chapitres de Silly Hope.\nAppuyez maintenant sur le bouton Retour de votre appareil pour ouvrir le menu et quitter.";
                tutorialEnd = "Commencez l'aventure";
                break;

            case 4: //Эсперанто
                headphones = "Ni rekomendas uzi aŭdilojn por plej bona videoludado";
                playTutorial = "Salti la lernilo";
                skipTutorial = "Skip Tutorial";
                pauseHeader = "Pauzo";
                @continue = "Daŭru";
                restart = "Rekomenci";

                victoryHeader = "Venko!";

                deathHeader = "Ne venko";

                exit = "Eliri";
                confirmationHeader = "Ĉu vi certas, ke?";
                confirmationYes = "Jes";
                confirmationNo = "Ne";

                bestScore = "Plej bona poentaro:";
                equipment = "Ekipo";
                shop = "Vendejo";
                content = "Enhavtabelo";
                settings = "Agordo";
                next = "Pliaj";
                back = "Returne";
                previous = "Antaŭa";
                following = "Sekvante";
                select = "Electi";
                purchase = "Aĉeti";
                currentWeapon = "Armilo: ";
                currentArmor = "Kiraso: ";
                currentTalisman = "Amuleto";
                graphicsLow = "Grafiko: malalta";
                graphicsNormal = "Grafiko: normala";
                volume = "Volumeno:";
                this.language = "Lingvo: Esperanto";

                longsword = "Longoglavo";
                brokenSword = "Rompita glavo";
                falchion = "Falchion";
                zweichender = "Zweihander de Templanoj";
                peterSword = "Glavo de Petro";
                januariusDagger = "Dagger de la sango de Januario";
                spear = "Sankta Lanco";
                russianSword = "Kovrita per oleo-glavo";

                longswordDescription = "La plej bona glavo por longaj bataloj kaj jardaj bataletoj. Permesas al vi bati malamikojn per potenca bato de du-mana kroĉado kaj mortigi per unu mano, samtempe protektante vin kun la alia.";
                brokenSwordDescription = "Mi ne povas kredi, ke iu sufiĉe mutas uzi rompitan glavon! Li estas tute senutila! Uzi ĝin en batalo estas memmortigo.";
                falchionDescription = "Estas malfacile liveri ponardon per ĝi, kaj por trafi la defendon de iu, vi devas meti vian manon multe malantaŭ la kapo. Se vi interŝanĝos ĝin per bovlo da supo, tiam ĝi alportos pli multajn avantaĝojn.";
                zweichenderDescription = "Ilia tempo finiĝas, same kiel la tempo de la kavaliroj. Baldaŭ nek unu nek la alia restos, kaj anstataŭ ili venos homoj sen honoro kaj fido al la Sinjoro.";
                peterSwordDescription = "Ili diras, ke per tia glavo unu el la apostoloj fortranĉis la orelon de sklavo. Ŝajne, la apostolo ne havis sufiĉe da lerteco por mortigi viron.";
                januariusDaggerDescription = "Mi povas senti ĝin brulanta en miaj manoj. Bona signo por magia talismano, sed ĉu ĝi estos oportuna dum serioza batalo?";
                spearDescription = "Antaŭe servis kiel armilo en la murdo de la filo de la Sinjoro, nun ĉi tiu lanco trovas novan celon.";
                russianSwordDescription = "Eleganta solvo por malglataj armiloj. Tamen mi ankoraŭ ne povas alkutimiĝi al la ideo, ke mi devas uzi la armilojn de la slavoj.";

                longswordLoadingScreenDescription = "La longa glavo, nomata romanika, nomata Kapetiano, ankaŭ bastarda glavo - estas la plej populara armilo de militistoj el Eŭropo dum la Alta Mezepoko.\nLi plej postulis kavalirojn kaj militistojn de princoj de Rusio pro ĝia fleksebleco en uzo.\nMalgraŭ sia impresa grandeco kaj timema aspekto, tiaj armiloj ofte estas uzataj kiel malĉefa, se ne nur intimidantaj kontraŭuloj.";
                brokenSwordLoadingScreenDescription = "Ĉiu homo, kiu almenaŭ iom versas militon, scias, ke glavo estis speciala afero por militisto kaj porti ĝin ofte signifas aparteni al alta milita rango. \nAnkaŭ ne forĵetu la fakton de parenceco inter veterano. de bataloj kaj lia lojala klingo - kaj glavo fariĝas la kamarado tro malfacila por rezigni eĉ post lia " + '"' + " morto " + '"'+ ".\nTio okazis kun ĉi tiu glavo.";
                falchionLoadingScreenDescription = "Falchion estas eŭrop-mana armilo kun pligrandigo de la fino de la klingo, perfekte taŭga por pikado kaj disbatado de batoj.\nEn kristanismo, unu kurioza epizodo estas kun li priskribita en la Evangelio de Johano, dum kiu la apostolo Petro, kiu klopodis rezistu, detranĉu la orelon de ĉefpastra servisto nomata Malchus.\nTial ĉi tiu armilo estas konata ankaŭ kiel " + '"'+" Malchus "+'"' + ".";
                zweichenderLoadingScreenDescription = "Ĉi tiu armilo havas, kiel ĉiuj aliaj du-manaj glavoj, imponan kaj larĝan klingon.\nĜi permesas al vi fari potencajn batojn, kio faras ĉiun svingon vere mortiga.\nTamen nur la plej fortaj kaj plej lertaj militistoj povas uzi ĝin. \n Pro siaj proprecoj, la du-mana brako estis populara ene de Templaro, kiu uzis ĝin dum sia ekzisto.";
                peterSwordLoadingScreenDescription = "Mallonga unu-mana glavo, laŭ legendo, apartenis al unu el la apostoloj de Kristo.\nSed nekomforte delokita centro de la amaso, la kurba gvardio kaj la jam eluzita surskribo sur la pomelo parolas pli pri malkvalita falsaĵo ol de sankta relikvo.";
                januariusDaggerLoadingScreenDescription = "Laŭ legendo, ĉi tiu delikata pugno estis forĝita el alojo el ŝtalo, makulita per la sango de la granda martiro Januario.\nTiu sanktulo estas konata pro la fakto, ke dufoje li savis sin kaj siajn kunulojn de la morto mirakle. la senkompata varmego de la forno kaj tiam de la akraj franĝoj de sovaĝaj bestoj.\nKiu scias, eble la klingo povos doni al sia posedanto la saman bonŝancon, aŭ eĉ rekompencon de nenatura longa vivo.";
                spearLoadingScreenDescription = "Sankta Lanco estas unu el la plej gravaj kristanaj artefaktoj, tre rilata al la Pasio de Kristo. \n Laŭ legendo, ĝi apartenis al la romia centestro Longino, kiu batis la krucumitan profeton ĝuste en la koro sen damaĝi siajn ostojn. Ĉi tiu " + '"' + " bato de kompatemo " + '"' + " dotis la armilon per sankteco, kio permesis al ĝi fariĝi ne nur la plej granda relikvo de kristanismo, sed ankaŭ la plej forta manifestiĝo de la potenco de la Sinjoro en ĉi tio mondo.";
                russianSwordLoadingScreenDescription = "Surprize, kiel foje aferoj povas aperi en iuj neatenditaj lokoj.Ĉi tiu klingo, iam forĝita en Rusujo, faris sian vojon tra la tuta Eŭropo kaj partoprenis en diversaj bataloj.Sed eĉ por la plej granda militisto la jarcento de bataloj pasas, kaj venas la tempo de forgeso.\nSed foje okazas, ke nova vivo estas enpuŝita en la malnova armilo, same kiel veterano trovas alian vokon.Ĉu la flamo de lia estado ekbruliĝos al cindro? Aŭ ĉu ĝi lumigos la vojon al la estonteco?";

                lightArmor = "Malpeza Kiraso";
                chainMail = "Ĉenero";
                strengthenedChainMail = "Plifortigita Ĉenero";
                heavyArmor = "Peza Kiraso";

                lightArmorDescription = "Baza kiraso. La elementoj de la kiraso estas eluzitaj, kaj eĉ ŝajnas esti atingo. Tamen, kion alian atendi de kiraso, kiu eltenis vojaĝon tra la mondo?";
                chainMailDescription = "La plej ofta kavalira kiraso. Ĝi estas ringo teksita kune en ununura ŝtofo. Protektas la tutan korpon.";
                strengthenedChainMailDescription = "Plibonigita versio de la ĉena poŝto. Ĉi tio manifestiĝas en pli streĉa taŭgeco de la ringoj kaj pliigo de ilia nombro. Krome la sub kiraso ne plu odoras al rusto!";
                heavyArmorDescription = "Plej potenca kirasa aro. Signife pliigas la eblecon eliri la batalon sen vundoj nekongruaj kun la vivo.\nTute ankaŭ kapablas fari sian posedanton pli brutala.";

                lightArmorLoadingScreenDescription = "Paro de brakringoj, simpla surbrustaĵo, kasko kaj ĉifonoj - kaj la plej bona kiraso por la crook estas preta. Sur la batalkampo, tia militisto elstaras el la homamaso kaj ŝajnas facila celo.\nTamen, sub la viziero povas kaŝi ambaŭ malriĉulo - aventuristo kaj sperta veterano, preta instrui kelkajn lecionojn al tro arogantaj kontraŭuloj.\nKaj la malpeza pezo de la kiraso ne malhelpas movadon, permesante kun facileco bati kaj malhelpi batojn.";
                chainMailLoadingScreenDescription = "Ringo kiraso - kiraso teksita el feraj ringoj, metala reto por protekti kontraŭ batoj de hakilo, glavo aŭ ponardo. Estas multaj varioj de ĉi tiu kiraso, de mallongaj ĉemizoj, kiuj kovras nur la bruston kaj abdomenon, ĝis reala haŭto, kiu protektas la tutan korpon krom la vizaĝo kaj brakoj ĝis la kubutoj.\nFacile por fari kaj ripari (truoj en ĉena poŝto povas estu parigita kun nova peco de ĉena poŝto).";
                strengthenedChainMailLoadingScreenDescription = "Kontraste al konvencia ĉena poŝto, muntita versio de ĝi estas farita de pli fortaj alojoj kun plurfoje pli agrablaj ringoj unu al la alia, kio ebligas al vi ĉesi ne nur batojn de la klingoj, sed ankaŭ eksplodon.\nKaj aldona protekto ankaŭ estas provizita. per densigita tolo sub la armilo.";
                heavyArmorLoadingScreenDescription = "Militistoj estas tre malsamaj laŭ naturo. Por iuj gravas, rapideco kaj manovrebleco. Aliaj preferas duŝi siajn malamikojn per sagoj de proksima monteto.\nBone estas tiuj, kiuj volas senti sin kiel morta armilo. Vestitaj per peza kunmetita kiraso, kun grandega glavo preta, ili mordas la malamikan formadon kaj lasas neniun viva tie. Por tiaj homoj, peza kiraso ekzistas.";

                noCharm = "Neniu elektita";
                welfareCharm = "Bonstato amuleto";
                hereticCharm = "L'amuleto de Heretic";
                orderCharm = "L'amuleto de Ordo";
                crucifix = "Krucifikso";
                ivoryPommel = "Ebura butono";
                popeSeal = "Sigelo de Papo";
                traitorPendant = "Pendanto de perfidulo";

                welfareCharmDescription = "Ligna statueto en formo de maljuna saĝulo mergita en profundaj pensoj. Ĉiu viro de la vilaĝo ricevas ĝin en la aĝo de dekoka. Porti ĝin donas al la portanto kapablon bati pli forte.";
                hereticCharmDescription = "Mistera potenco de la monto donis ĉi tiun amuleton al tiuj, kiuj estis en danĝero de la eklezio. Post ĉi tiu " + '"' + "rekompenco" + '"' + ", persono fariĝas pli malforta pro konstanta timo, sed lia pliigita singardo igas lin ankaŭ pli obstina. Post la morto de la posedanto, amuleto malaperas.";
                orderCharmDescription = "Unu el la plej oftaj aferoj en la Sankta Ordono de Konservado. Eldonita al ĉiu rekruto ĉe la iniciata ceremonio. Ĉar, dum sia plej bona tempo, servo al la ordo estis granda honoro, ĉiuj portantoj de la talismano plifortiĝis en spirito.";
                crucifixDescription = "Monaastica kruco portata de ĉiuj pastroj en la Sankta Ordo de la Konservado. Danke al ilia forta fido al Dio, subtenata de ĉi tiu afereto, la monaksoj furioze batalis ĝis la lasta. Tamen iliaj batoj estis malfortaj.";
                ivoryPommelDescription = "Laŭ legendo, ĝi apartenis al la butono unua Granda Majstro de la Ordeno - Emzsore. Estis ankaŭ legendoj pri lia vanteco: aro da skribistoj, sub minaco de morto, priskribis lian tutan vivon tre detale.";
                popeSealDescription = "En la lastaj jarcentoj, ĉiuj destinoj de la mondo estas deciditaj de unu homo. Papo. Ĉi tiu viro scias ĉion, li trankvile sendas milojn da homoj al la milito por la sankta lando. Ne mirinde, ke tiu, kiu portas sian sigelon, scias ankaŭ iom pli pri la mondo ol ordinara homo.";
                traitorPendantDescription = "La pendanto de perfidulo estas ia gesto de la flanko de la Sankta Ordono de Konservado al tiuj, kiuj malsukcesis ĝiajn statutojn. Homo, kiu portas tian aferon, estas animo kondamnita al turmento, en la iluzia espero elaĉeti ilin. Sed ĉi tiu vojo donas nekredeblajn ŝancojn.";

                welfareCharmLoadingScreenDescription = "Simpla ĉarmo, kiu aspektas kiel proksimume ĉizita el ligna ridinda homo, kiun vi ne volos meti sur vin. Tamen ne ĉio estas tiel simpla.\nLaŭ la kredoj de lokaj loĝantoj, ĉi tiu kaj similaj ĉarmoj alportas al la posedanto bonŝancon, feliĉon kaj savas lin de hazarda sago. Eble ĉi tio estas nur superstiĉo, sed unu afero estas certa: la ĉarmo aldonas fidon je la atako de posedanto.";
                hereticCharmLoadingScreenDescription = "Alia kurioza artefakto de lokaj loĝantoj. Dum la regado de la eklezio super la vilaĝo, multaj el ĝiaj loĝantoj estis torturitaj kaj persekutitaj de la krucistoj, kaj poste de la monaksoj.\nLa talismano ĉi tie havis la rolon de sekreta instrukcio de nekonata forto de la supro de Unheimberg, tiel ke la eklezianoj nenion suspektus kaj ebligis eskapi kaj kaŝi.";
                orderCharmLoadingScreenDescription = "Unu el la plej oftaj artefaktoj en la Sankta Ordo de Konservado, ĝi estis donita al ĉiu kavaliro post la iniciata ceremonio.\nĈi tiu afero signifis, ke la neofito estos fidela al la ordo ĝis la fino de siaj tagoj kaj plenumos iun ajn faron en Lia gloro. . Eĉ se ĉi tiu ago signifus morton.\nMultaj ankaŭ kredis, ke la Sinjoro protektas ilin kiel siajn elektitojn.";
                crucifixLoadingScreenDescription = "Alia restaĵo de la Sankta Ordono de Konservado. Ĝi estas disvastigita en la monaastica parto de la ordo. Ĝi estas malgranda kruco, simbola kopio de tiu, sur kiu Jesuo estis krucumita.\nEstas du metodoj por porti la krucon: laikoj portas ĝin sub siaj vestaĵoj, dum ekleziaj oficialuloj kaj kavaliroj povas porti ĝin super ĝi.\nLa kruco donas fidon al dia vero.";
                ivoryPommelLoadingScreenDescription = "Supoj nomataj la supro de iuj produktoj, inkluzive de tenilo de klingo, bastono, ktp., Aŭ strukturoj (turo aŭ kupolo).\nParolante eburan selobutonon, ĝi signifas tenilon de glavo, alie vi ne estus kapabla batali.\nLaŭ legendo ĝi apartenis al la unua granda majstro de ordo - Emzore.";
                popeSealLoadingScreenDescription = "La Papo-Sigelo, aŭ la Fiŝkaptista Ringo, estas unu el la plej kuriozaj artefaktoj de la Vatikana Kortego. La ringo prezentas la Apostolon Petron en la rolo de fiŝkaptisto ĵetanta fiŝreton de boato en la maron.\nĈi tio estas pro la fakto, ke en la monduma vivo Petro estis fiŝkaptisto, kaj ankaŭ per la vortoj de Jesuo, ke liaj disĉiploj farus fariĝu fiŝkaptistoj de homaj animoj. Plej verŝajne imitaĵo.";
                traitorPendantLoadingScreenDescription = "Artefakto de la Sankta Ordono de Konservado. Ĝi estas medaljono prezentanta funebranton en kapuĉo, super kiu estas portita dornokrono.\nUnuflanke ĝi simbolas la profundan malĝojon por la animo de perfidulo kaj igas lin alvoko por pekliberigo de pekoj martiro aliflanke.\nVestado rilatas al nekredebla sufero.";

                prologue = "Antaŭparolo: Alveno";
                epilogue = "Epilogo";
                titles = "Kreditoj";
                chapter1 = "Ĉapitro 1: Vilaĝo";
                chapter2 = "Ĉapitro 2: Sturmo";
                chapter3 = "Ĉapitro 3: Eskapi";
                chapter4 = "Ĉapitro 4: Memoroj";
                chapter5 = "Ĉapitro 5: Defendantoj";
                chapter6 = "Ĉapitro 6: Alfrontiĝo";
                chapter7 = "Ĉapitro 7: Ent";
                chapter8 = "Ĉapitro 8: Entombigo";
                chapter9 = "Ĉapitro 9: Laboratorioj";
                chapter10 = "Ĉapitro 10: Trono";
                chapter11 = "Ĉapitro 11: Nekromancisto";

                popUpNowAvailable = "Nun havebla";
                popUpSizeUpdate = "Ataka limo de stokado pliiĝis al";
                popUpNewCombo = ". Novaj komboj disponeblas";
                popUpOk = "Bone";

                tutorialPoints = "Por kapti punkton, tuŝekrano sur la areo, kiun la punkto sekvas, kiam punkto estas sur la blanka linio. Kaptu tri poentojn.";
                tutorialCombometer = "Kiam vi kaptos kvar samkolorajn punktojn, la armilo de Sebastiano ekbrulos, kaj li estos preta bati. Malpeza kavalira glavo.";
                tutorialAttack = "Kiam la armilo ekbrulas, kavaliro povas ataki. Movu la portreton de via kontraŭulo maldekstren por normala (verda) atako, kaj dekstren por peza (ruĝa) atako.";
                tutorialEnemy = "Ĉiu punkto, kiun vi maltrafis, kalkulas al la malamiko. La malamiko tuj atakos kavaliron se ili kolektos sufiĉe da punktoj. Venku lin antaŭ ol li mortigos Sebastian.";
                tutorialExit = "Vi ricevas inkon por mortigi kontraŭulojn, kiun vi povas elspezi por aĉeti armilojn aŭ la sekvajn Ĉapitrojn de Stulta Espero.\nNun premu la butonon Reen de via aparato por malfermi la menuon kaj eliri.";
                tutorialEnd = "Komencu la aventuron";
                break;

            default:
            goto case 0;
        }
    }
}
