using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{
    public class LeetCodeProblem3
    {
        // Definition for singly-linked list
        public class ListNode
        {
            public int Val;
            public ListNode Next;

            public ListNode(int val)
            {
                Val = val;
            }
        }

        // Method to create a linked list from an array
        public async static Task<ListNode> CreateList(int[] data)
        {
            ListNode head = null;
            ListNode current = null;

            foreach (int val in data)
            {
                ListNode newNode = new ListNode(val);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    current.Next = newNode;
                }
                current = newNode;
            }

            return head;
        }

        // Method to detect cycle in a linked list
        public static bool HasCycle(ListNode head)
        {
            ListNode slow = head, fast = head;
            if (head == null || head.Next == null)
                return false;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        // Main method to test linked list cycle detection
        public async static void LinkedListProblem()
        {
            int[] listData = { 3, 2, 0, -1 };
            ListNode head = await CreateList(listData);
            bool hasLoop = HasCycle(head);
            Console.WriteLine(hasLoop);
        }

        public static void Main(string[] args)
        {
            LinkedListProblem();
        }
    }
}
