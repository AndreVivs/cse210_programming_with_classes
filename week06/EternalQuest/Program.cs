using System;

/*
EXCEEDING REQUIREMENTS:

1. Daily Streaks:
   I implemented a streak tracking system that rewards consistency.
   Each goal tracks the number of consecutive days the user records
   an activity. Streak progress is also saved and loaded.

2. Milestone Rewards:
   I added a reward system that grants bonus points when the user
   reaches specific score milestones (500, 1000, 2500, and 5000).
   Each reward can only be claimed once, and claimed milestones
   are saved and restored when loading the program.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
