#include<iostream> 
using namespace std;
struct Node {
     int data;
    Node * next;
    Node();
    Node(int d, Node* link = NULL);
}; 

Node::Node()
{
    next = NULL;
}

Node::Node(int item, Node* link)
{
    data = item;
    next = link;
} 


class SortedLinkedList {
public:    // methods of the SortedLinkedList ADT 
    SortedLinkedList(); //default constructor 
    ~SortedLinkedList(); //destructor 
    bool isFull();
    bool isEmpty();
    void makeEmpty();
    int SortedLinkedListSize();
    void printSortedLinkedList();
    bool search(int item);
    int retrieve(int item);
    int deleteItem(int item);
    void addSortedItem(int item);
    bool ListEqual(SortedLinkedList A2);

private:     // data members for linked SortedLinkedList implementation 
    int count;
    Node* first;
};//SortedLinkedList 

    bool SortedLinkedList::isEmpty()
    {
     return count == 0;
    }// return first == NULL; }//empty 

    SortedLinkedList::SortedLinkedList()
    {
        count = 0;
        first = NULL;
    }//empty 

    SortedLinkedList::~SortedLinkedList()
    {
        count = 0;
        Node* temp;
        while (first != NULL)
        {
            temp = first;
            first = first->next;
            delete temp;
        }
    }//~SortedLinkedList 

    int SortedLinkedList::SortedLinkedListSize()
    {
        return count;
    }//SortedLinkedListSize 

    bool SortedLinkedList::isFull()
    {
        bool result = false;
        Node* temp;
        temp = new Node();
        if (temp == NULL) result = true;
        else         delete temp;
        return result;
    }//isFull 

    void SortedLinkedList::makeEmpty()
    {
        count = 0;
        Node* temp;
        while (first != NULL)
        {
            temp = first;
            first = first->next;
            delete temp;
        }
    }//makeEmpty 

    void SortedLinkedList::addSortedItem(int item) 
    {
        if (isFull()) {
            cout << "SortedLinkedList overflow\n";
            return; //return to the calling function 
        }
        else {
          //  first = new Node(item, first);
            if (first == NULL) {
                first = new Node(item);
            }
            else {
                if (first->data > item) {
                    Node* tempor;
                    tempor = new Node(item);
                    tempor->next = first;
                    first = tempor;
                }
                else {
                    Node* CurrentNode = first;
                    while (CurrentNode->next != NULL && CurrentNode->next->data < item) {
                        CurrentNode = CurrentNode->next;
                    }

                    Node* tempor;
                    tempor = new Node(item);
                    tempor->next = CurrentNode->next;
                    CurrentNode->next = tempor;
                    // tempor = new Node(item);
                }
            }
            count++;
            
        }
    }//addItem 

    bool SortedLinkedList::search(int item)
        //returns true if item is in SortedLinkedList, false otherwise 
    {
        Node* p = first;
        while (p != NULL)
        {
            if (p->data == item)  return true;
            else   p = p->next;
        }//while 
        return false;
    }//search 

    void SortedLinkedList::printSortedLinkedList()
    {
        cout << "SortedLinkedList content:\n";
        if (count == 0)
            cout << "SortedLinkedList is empty.\n";
        Node* p = first;
        while (p != NULL)
        {
            cout << p->data << ", ";
            p = p->next;
        }//while 
        cout << endl;
    }//printSortedLinkedList 

    int SortedLinkedList::retrieve(int item)
    {
        Node* p = first;
        while (p != NULL)
        {
            if (p->data == item)  return p->data;
            else   p = p->next;
        }//while 
        cout << "item was not found, was not retrieved\n";
        return -10000; //to signal not found  
    }//retrieve 

    int SortedLinkedList::deleteItem(int item)
    {
        int result = 0;
        if (isEmpty()) {
            cout << "SortedLinkedList underflow\n";
            return -10000;
        }
        Node* previous = NULL, * following = first;  while (following != NULL && following->data != item)           //searching for item 
        {
            previous = following;
            following = following->next;
        }//while  //deleting 1st node 
        if (previous == NULL && following != NULL && following->data == item)
        {
            result = following->data;
            first = first->next;
            delete following; //releasing memory 
            count--;
            return result;
        }
        else
            if (previous != NULL && following != NULL && following->data == item) {
                result = following->data;                 //deleting not 1st  node. 
                previous->next = following->next;
                delete following;
                count--;


                

                    return result;
            }
            else        //item was not found 
            {
                cout << "Item was not found and not deleted\n";
                return -10000;
            }
    }//deleteItem

    bool SortedLinkedList::ListEqual(SortedLinkedList A2) {
        Node* perv = first, * vtor = A2.first;

        //if (perv == NULL) return true;
        if (perv == NULL && vtor == NULL) return true;
        if (perv == NULL && (vtor != perv) ) return false;
        if (vtor == NULL && (vtor != perv)) return false;      
       /* perv = perv->next;
        vtor = vtor->next;*/

        while (perv != NULL && vtor != NULL) {
            if (perv->data != vtor->data) return false;
            perv = perv->next;
            vtor = vtor->next;
        }

        if ((perv == NULL && vtor == NULL) ) return true;
        else return false;
    }




        int main()
        {
            int n = 0, x = 0;

            SortedLinkedList A;
            cout << "Enter number of elements in list 1:\n";
            cin >> n;
            cout << "Enter elements:\n";
            for (int i = 0; i < n; i++) {
                cin >> x;
                A.addSortedItem(x);
            }
            A.printSortedLinkedList();

            SortedLinkedList A2;
            cout << "Enter number of elements in list 2:\n";
            cin >> n;
            cout << "Enter elements:\n";
            for (int i = 0; i < n; i++) {
                cin >> x;
                A2.addSortedItem(x);
            }
            A2.printSortedLinkedList();

            if (A.ListEqual(A2)) cout << "Lists 1 and 2 are equal \n";
            else cout << "List 1 and 2 are different";

            return 0;

            return 0;
           // SortedLinkedList A; //object A of class SortedLinkedList with int items Note: without parenthesis!! 
           //     A.addSortedItem(20);
           // A.printSortedLinkedList();
           //     A.addSortedItem(30);
           // A.printSortedLinkedList();
           //     A.addSortedItem(40);
    
           // A.printSortedLinkedList();
           // 
           // A.addSortedItem(15);
           // A.printSortedLinkedList();
           // if (A.search(30))
           //     cout << "deleted item = " << A.deleteItem(30) << endl;
           // else  cout << "Item was not found. Item was not deleted\n";
           // A.printSortedLinkedList();
           //if (A.search(70))
           //  cout << "deleted item = " << A.deleteItem(70) << endl;
           //else  cout << "Item 70 was not found.Item was not deleted\n " ;
            //A.printSortedLinkedList();
            ////deleting without checking the precondition 
            //cout << "deleted item = " << A.deleteItem(60) << endl;
            //A.printSortedLinkedList();
            //cout << "retrieved item = " << A.retrieve(40) << endl;  //without checking the precondition 
            //A.printSortedLinkedList();
            //cout << "SortedLinkedList size = " << A.SortedLinkedListSize() << endl;
        }//main 