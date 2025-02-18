#include <stdio.h>
#include <stdlib.h>
#include <string.h>
//Queue
struct Queue{
    int size;
    int prior;
    int added;
    int *data;
    int worked;
};
void Queue_Create(struct Queue* queue, int prior){
    queue->data =(int*) malloc(0 * sizeof(int));
    queue->size = 0;
    queue->prior = prior;
    queue->added = 0;
    queue-> worked = 0;
}
void Queue_Add(struct Queue* queue, int val){
    queue->data = (int*) realloc(queue->data, (queue->size + 1) * sizeof(int) );
    queue->data[queue->size] = val;
    queue->size++;
}
int Queue_Top(struct Queue* queue){
    return queue->data[0];
}
void Queue_DeleteTop(struct Queue* queue){
    for (int i = 0; i < queue->size - 1; i++){
        queue->data[i] = queue->data[i + 1];
    }
    queue->data = (int*)realloc(queue->data, (queue->size - 1) * sizeof(int));
    queue->size--;
}
//Queue

//Priority Queue
struct  PriorityQueueHead{
    struct Queue** data;
    int size;
};
int Compare(struct Queue* a, struct Queue* b) {
    return b->prior >  a->prior;
}
void PriorityQueue_SiftUp(struct PriorityQueueHead* queue, int pos){
    if (Compare(queue->data[pos],queue->data[(pos - 1) / 2])){
        struct Queue* temp = queue->data[pos];
        queue->data[pos] = queue->data[(pos - 1) / 2];
        queue->data[(pos - 1) / 2] = temp;
        PriorityQueue_SiftUp(queue, (pos - 1) / 2);
    }
}
void PriorityQueue_SiftDown(struct PriorityQueueHead* queue, int pos){
    if ((pos * 2 + 1 ) < queue->size) {
        int betterafter = pos * 2 + 1;
        if (queue->size > (pos * 2 + 2)) {
            if (!Compare(queue->data[pos * 2 + 1], queue->data[pos * 2 + 2])) {
                betterafter++;
            }
        }
        if (Compare(queue->data[betterafter], queue->data[pos])) {
            struct Queue *temp = queue->data[pos];
            queue->data[pos] = queue->data[betterafter];
            queue->data[betterafter] = temp;
        }
        PriorityQueue_SiftDown(queue, betterafter);
    }
}
struct Queue* PriorityQueue_GetElem(struct PriorityQueueHead* queue, int pos){
    for (int i = 0; i <queue->size;i++){
        if ((queue->data[i]->added > queue->data[pos]->added) && (queue->data[i]->prior == queue->data[pos]->prior)) {
            queue->data[i]->added--;
        }
    }
    struct Queue* result = queue->data[pos];
    queue->data[pos] = queue->data[queue->size - 1];
    PriorityQueue_SiftDown(queue, pos);
    queue->data = (struct Queue**) realloc(queue->data, (queue->size - 1) * sizeof(struct Queue*) );
    queue->size--;
    return result;
}
void PriorityQueue_Add(struct PriorityQueueHead* queue, struct Queue* val){
    int counter = 0;
    for (int i = 0; i < queue->size; i++){
        if (queue->data[i]->prior == val->prior){counter++;}
    }
    queue->data = (struct Queue**) realloc(queue->data, (queue->size + 1) * sizeof(struct Queue*) );
    queue->data[queue->size] = val;
    val->added = counter;
    PriorityQueue_SiftUp(queue, queue->size);
    queue->size++;
}

void PriorityQueue_Create(struct PriorityQueueHead* queue) {
    queue->data =(struct Queue**) malloc(0 * sizeof(struct Queue*));
    queue->size = 0;
};
//Priority Queue

void UpdateChillingTime(struct PriorityQueueHead* queue, int chillingTime, int workTime){
    for (int i = 0; i < queue->size;i++){
        if (queue->data[i]->data[0] <= 0) {
            if (queue->data[i]-> worked != 1){
                queue->data[i]->data[0] -= workTime;
            }
            if  ((queue->data[i]-> worked == 0) && (queue->data[i]->data[0] <= -chillingTime)){
                Queue_DeleteTop(queue->data[i]);
            }

        }
        queue->data[i]->worked = 0;

    }

}

void WorkOut(struct PriorityQueueHead* queue, int workTime, int chillingTime){
    int idealprior = INT_MAX;
    int idealindex = -1;
    int idealadded = INT_MAX;
    for (int i = 0; i < queue->size; i++)
        if ((queue->data[i]->prior < idealprior) ||
            ((queue->data[i]->prior == idealprior) &&
             (queue->data[i]->added < idealadded))){
            if ((queue->data[i]->size > 0) && (queue->data[i]->data[0] > 0)){
                idealindex = i;
                idealprior = queue->data[i]->prior;
                idealadded = queue->data[i]->added;
            }
        }
    if (idealindex != -1){
        queue->data[idealindex]->data[0] -= workTime;
        queue->data[idealindex]->worked = 1;
        int toCompute;
        while (-queue->data[idealindex]->data[0] >= chillingTime){
            toCompute = -queue->data[idealindex]->data[0] - chillingTime;
            Queue_DeleteTop(queue->data[idealindex]);
            if (queue->data[idealindex]->size > 0){
                queue->data[idealindex]->data[0] -= toCompute;
            } else {
                break;
            }
        }
        struct Queue* temp;
        temp = PriorityQueue_GetElem(queue,idealindex);
        if ((temp->size > 1) || ((temp->size== 1) && (temp->data[0] > 0))){
            PriorityQueue_Add(queue,temp);
        }
    }
}

struct Queue* CloneQueue(struct Queue* src) {
    struct Queue* clone = (struct Queue*)malloc(sizeof(struct Queue));
    clone->size = src->size;
    clone->prior = src->prior;
    clone->added = src->added;
    clone->worked = src->worked;
    clone->data = (int*)malloc(src->size * sizeof(int));

    for (int i = 0; i < src->size; i++) {
        clone->data[i] = src->data[i];
    }

    return clone;
}

struct PriorityQueueHead* ClonePriorityQueue(struct PriorityQueueHead* src) {
    struct PriorityQueueHead* clone = (struct PriorityQueueHead*)malloc(sizeof(struct PriorityQueueHead));
    clone->size = src->size;
    clone->data = (struct Queue**)malloc(src->size * sizeof(struct Queue*));

    for (int i = 0; i < src->size; i++) {
        clone->data[i] = CloneQueue(src->data[i]);
    }

    return clone;
}

int main(){

/*
 21 tacts kpd  57/84
 3 4 3
 1 5    1 6 7 1 2
 2 4    5 3 9 4
 2 4    2 7 5 5


 13tacts  kpd 28/39
 3 3 5
 1 3   4 5 3
 2 3   3 2 3
 2 3   1 4 3

 7 5
 6
 1 9    6 4 3 4 6 8 5 9 7
 2 10   3 2 1 6 8 9 7 4 3 1
 2 10   2 1 2 3 1 6 1 8 9 7
 2 10   5 3 5 6 6 7 8 2 1 8
 3 11   5 4 3 2 1 8 7 6 3 2 1
 3 11   5 9 3 1 2 9 7 6 4 2 1

 6,4,3,4,6,8,5,9,7,0,0
 3,2,1,6,8,9,7,4,3,1,0
 2,1,2,3,1,6,1,8,9,7,0
 5,3,5,6,6,7,8,2,1,8,0
 5,4,3,2,1,8,7,6,3,2,1
 5,9,3,1,2,9,7,6,4,2,1

 1,2,2,2,3,3

*/
    int result = 0;
    int n; //workTime, chillTime;
    scanf("%d", &n);
    struct PriorityQueueHead PriorityQueue;
    PriorityQueue_Create(&PriorityQueue);
    for (int i = 0; i < n; i++) {
        int k, prior, tempInput;
        scanf("%d%d", &prior, &k);
        struct Queue newQueue;
        Queue_Create(&newQueue, prior);
        for (int j = 0; j < k; j++) {
            scanf("%d", &tempInput);
            result += tempInput;
            Queue_Add(&newQueue, tempInput);
        }
        struct Queue *queueToAdd = (struct Queue *) malloc(sizeof(struct Queue));
        memcpy(queueToAdd, &newQueue, sizeof(struct Queue));
        PriorityQueue_Add(&PriorityQueue, queueToAdd);
    }
    for (int chillTime = 0; chillTime <= 10; chillTime++) {
         for (int workTime = 1; workTime <= 10; workTime++) {


            struct PriorityQueueHead* clonedPriorityQueue = ClonePriorityQueue(&PriorityQueue);
           /*
            for (int i = 0; i < clonedPriorityQueue->size; i++) {
                for (int j = 0; j < clonedPriorityQueue->data[i]->size; j++) {
                    printf("%d ", clonedPriorityQueue->data[i]->data[j]);
                }
                printf("\n");
            }
            printf("\n\n\n");
            */

            int stage = 0;
            while (clonedPriorityQueue->size != 0) {
                WorkOut(clonedPriorityQueue, workTime, chillTime);
                UpdateChillingTime(clonedPriorityQueue, chillTime, workTime);
                stage++;
            }

            printf("tacttime, breaktime:%d,%d  stage:%d values:%d/%d\n", workTime, chillTime, stage, result, stage * workTime);

            for (int i = 0; i < clonedPriorityQueue->size; i++) {
                free(clonedPriorityQueue->data[i]->data);
                free(clonedPriorityQueue->data[i]);
            }
            free(clonedPriorityQueue->data);
            free(clonedPriorityQueue);
        }
    }
    return 0;
}
