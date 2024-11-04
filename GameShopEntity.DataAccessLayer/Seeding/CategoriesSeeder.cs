using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameShopEntity.DataAccessLayer.Seeding
{
    internal class CategoriesSeeder : ISeeder<Categories>
    {
        private static readonly List<Categories> categories = new()
        {
            new Categories
            {
                Id = 1,
                Name = "Action",
                Description = "Games that emphasize physical challenges, including hand-eye coordination and reaction-time. Players often face fast-paced gameplay with a focus on combat and movement."
            },
            new Categories
            {
                Id = 2,
                Name = "Adventure",
                Description = "Games that prioritize story-driven experiences, often involving exploration and puzzle-solving. Players typically navigate through a narrative and interact with characters and environments."
            },
            new Categories
            {
                Id = 3,
                Name = "Role-Playing Game (RPG)",
                Description = "Games where players assume the roles of characters in a fictional setting. Players often engage in quests, develop their character's abilities, and experience an evolving story."
            },
            new Categories
            {
                Id = 4,
                Name = "Simulation",
                Description = "Games designed to replicate real-world activities or systems. These games can simulate anything from flying airplanes to managing a city, offering a realistic experience of the subject matter."
            },
            new Categories
            {
                Id = 5,
                Name = "Strategy",
                Description = "Games that require players to use planning and tactics to achieve victory. Players often manage resources, make decisions, and control units or characters to outsmart opponents."
            },
            new Categories
            {
                Id = 6,
                Name = "Sports",
                Description = "Games that simulate the practice of sports or physical activities. Players can engage in individual or team-based competitions, representing real-world sports such as football, basketball, or racing."
            },
            new Categories
            {
                Id = 7,
                Name = "Puzzle",
                Description = "Games that challenge players with logical problems or tasks. The objective is often to solve puzzles using critical thinking, pattern recognition, or spatial reasoning."
            },
            new Categories
            {
                Id = 8,
                Name = "Horror",
                Description = "Games designed to evoke fear, tension, and suspense. Players typically encounter terrifying situations, monsters, or psychological themes, often requiring them to survive or escape."
            },
            new Categories
            {
                Id = 9,
                Name = "Fighting",
                Description = "Games focused on close combat between characters. Players control fighters in one-on-one battles, utilizing special moves and combos to defeat opponents."
            },
            new Categories
            {
                Id = 10,
                Name = "Shooter",
                Description = "Games that involve shooting enemies using firearms or projectile weapons. These can be first-person shooters (FPS), where players see through the eyes of the character, or third-person shooters, where the camera is positioned behind the character."
            },
            new Categories
            {
                Id = 11,
                Name = "Platformer",
                Description = "Games that involve navigating a character across platforms and obstacles, often requiring jumping and climbing. Players typically overcome challenges to reach goals or complete levels."
            },
            new Categories
            {
                Id = 12,
                Name = "Racing",
                Description = "Games centered around racing vehicles against opponents or against the clock. These can include realistic simulations or arcade-style racing with power-ups and stunts."
            },
            new Categories
            {
                Id = 13,
                Name = "Open World",
                Description = "Games that feature expansive environments allowing players to explore freely. These games often include a mix of quests, exploration, and side activities within a large, interactive world."
            },
            new Categories
            {
                Id = 14,
                Name = "MMO (Massively Multiplayer Online)",
                Description = "Games that allow large numbers of players to interact in a virtual world. These games can include elements from various genres, often featuring character progression, trading, and cooperative gameplay."
            },
            new Categories
            {
                Id = 15,
                Name = "Roguelike/Roguelite",
                Description = "Games characterized by procedurally generated levels, permadeath, and turn-based gameplay. Players often collect items and face increasingly difficult challenges in a randomized environment."
            },
            new Categories
            {
                Id = 16,
                Name = "Metroidvania",
                Description = "A subgenre of action-adventure games that emphasize exploration and platforming. Players typically gain new abilities that allow them to access previously unreachable areas within a connected world."
            },
            new Categories
            {
                Id = 17,
                Name = "Battle Royale",
                Description = "A multiplayer mode where players fight to be the last one standing on a shrinking map, often involving scavenging for weapons and resources."
            },
            new Categories
            {
                Id = 18,
                Name = "Stealth",
                Description = "Games that emphasize avoiding detection and using stealth tactics to accomplish objectives. Players often need to navigate environments quietly and strategically."
            },
            new Categories
            {
                Id = 19,
                Name = "Idle/Incremental",
                Description = "Games where players make minimal actions to progress, often involving resource management and automation over time."
            },
            new Categories
            {
                Id = 20,
                Name = "Visual Novel",
                Description = "Interactive stories that focus on narrative and character development, often featuring branching storylines based on player choices."
            },
            new Categories
            {
                Id = 21,
                Name = "Rhythm",
                Description = "Games that challenge players to match their actions to the rhythm of music, often involving timing and coordination."
            },
            new Categories
            {
                Id = 22,
                Name = "Card Game",
                Description = "Games that use a deck of cards as the primary gameplay mechanic, often involving strategy and chance in card play."
            },
            new Categories
            {
                Id = 23,
                Name = "Board Game",
                Description = "Digital adaptations of traditional board games, often involving strategy, luck, and player interaction."
            },
            new Categories
            {
                Id = 24,
                Name = "Educational",
                Description = "Games designed to teach players about specific subjects or skills, often incorporating elements of fun and engagement."
            },
            new Categories
            {
                Id = 25,
                Name = "Survival",
                Description = "Games that challenge players to survive in a hostile environment, often involving resource management, crafting, and combat."
            },
            new Categories
            {
                Id = 26,
                Name = "Fantasy",
                Description = "Games set in a fictional universe often inspired by mythology and magic, allowing players to explore magical realms and engage with fantastical creatures."
            },
            new Categories
            {
                Id = 27,
                Name = "Sci-Fi",
                Description = "Games that explore futuristic or extraterrestrial themes, often involving advanced technology, space exploration, or dystopian societies."
            },
            new Categories
            {
                Id = 28,
                Name = "Historical",
                Description = "Games that are set in a specific historical period, often incorporating real events and figures into the gameplay."
            },
            new Categories
            {
                Id = 29,
                Name = "Management/Simulation",
                Description = "Games that focus on managing resources and making decisions to achieve specific goals, such as city-building or business management."
            },
            new Categories
            {
                Id = 30,
                Name = "Text-Based",
                Description = "Games that primarily use text for storytelling and interaction, often relying on player input to navigate the story."
            }

        };
        public void Seed(EntityTypeBuilder<Categories> builder) => builder.HasData(categories);
    }
}
