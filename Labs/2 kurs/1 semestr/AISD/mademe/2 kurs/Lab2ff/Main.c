#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

struct Queue {
    int size;
    int prior;
    int added;
    int* data;
    int worked;
};
void Queue_Create(struct Queue* queue, int prior) {
    queue->data = (int*)malloc(0 * sizeof(int));
    queue->size = 0;
    queue->prior = prior;
    queue->added = 0;
    queue->worked = 0;
}
void Queue_Add(struct Queue* queue, int val) {
    queue->data = (int*)realloc(queue->data, (queue->size + 1) * sizeof(int));
    queue->data[queue->size] = val;
    queue->size++;
}
int Queue_Top(struct Queue* queue) {
    return queue->data[0];
}
void Queue_DeleteTop(struct Queue* queue) {
    for (int i = 0; i < queue->size - 1; i++) {
        queue->data[i] = queue->data[i + 1];
    }
    queue->data = (int*)realloc(queue->data, (queue->size - 1) * sizeof(int));
    queue->size--;
}

struct  PriorityQueueHead {
    struct Queue** data;
    int size;
};
int Compare(struct Queue* a, struct Queue* b) {
    return b->prior > a->prior;
}
void PriorityQueue_SiftUp(struct PriorityQueueHead* queue, int pos) {
    if (Compare(queue->data[pos], queue->data[(pos - 1) / 2])) {
        struct Queue* temp = queue->data[pos];
        queue->data[pos] = queue->data[(pos - 1) / 2];
        queue->data[(pos - 1) / 2] = temp;
        PriorityQueue_SiftUp(queue, (pos - 1) / 2);
    }
}
void PriorityQueue_SiftDown(struct PriorityQueueHead* queue, int pos) {
    if ((pos * 2 + 1) < queue->size) {
        int betterafter = pos * 2 + 1;
        if (queue->size > (pos * 2 + 2)) {
            if (!Compare(queue->data[pos * 2 + 1], queue->data[pos * 2 + 2])) {
                betterafter++;
            }
        }
        if (Compare(queue->data[betterafter], queue->data[pos])) {
            struct Queue* temp = queue->data[pos];
            queue->data[pos] = queue->data[betterafter];
            queue->data[betterafter] = temp;
        }
        PriorityQueue_SiftDown(queue, betterafter);
    }
}
struct Queue* PriorityQueue_GetElem(struct PriorityQueueHead* queue, int pos) {
    for (int i = 0; i < queue->size; i++) {
        if ((queue->data[i]->added > queue->data[pos]->added) && (queue->data[i]->prior == queue->data[pos]->prior)) {
            queue->data[i]->added--;
        }
    }
    struct Queue* result = queue->data[pos];
    queue->data[pos] = queue->data[queue->size - 1];
    PriorityQueue_SiftDown(queue, pos);
    queue->data = (struct Queue**)realloc(queue->data, (queue->size - 1) * sizeof(struct Queue*));
    queue->size--;
    return result;
}
void PriorityQueue_Add(struct PriorityQueueHead* queue, struct Queue* val) {
    int counter = 0;
    for (int i = 0; i < queue->size; i++) {
        if (queue->data[i]->prior == val->prior) { counter++; }
    }
    queue->data = (struct Queue**)realloc(queue->data, (queue->size + 1) * sizeof(struct Queue*));
    queue->data[queue->size] = val;
    val->added = counter;
    PriorityQueue_SiftUp(queue, queue->size);
    queue->size++;
}

void PriorityQueue_Create(struct PriorityQueueHead* queue) {
    queue->data = (struct Queue**)malloc(0 * sizeof(struct Queue*));
    queue->size = 0;
};


void UpdateRestingTime(struct PriorityQueueHead* queue, int restingTime, int workTime) {
    for (int i = 0; i < queue->size; i++) {
        if (queue->data[i]->data[0] <= 0) {
            if (queue->data[i]->worked != 1) {
                queue->data[i]->data[0] -= workTime;
            }
            if ((queue->data[i]->worked == 0) && (queue->data[i]->data[0] <= -restingTime)) {
                Queue_DeleteTop(queue->data[i]);
            }

        }
        queue->data[i]->worked = 0;

    }

}


void WorkOut(struct PriorityQueueHead* queue, int workTime, int restingTime) {
    int idealprior = INT_MAX;
    int idealindex = -1;
    int idealadded = INT_MAX;
    for (int i = 0; i < queue->size; i++)
        if ((queue->data[i]->prior < idealprior) ||
            ((queue->data[i]->prior == idealprior) &&
                (queue->data[i]->added < idealadded))) {
            if ((queue->data[i]->size > 0) && (queue->data[i]->data[0] > 0)) {
                idealindex = i;
                idealprior = queue->data[i]->prior;
                idealadded = queue->data[i]->added;
            }
        }
    if (idealindex != -1) {
        queue->data[idealindex]->data[0] -= workTime;
        queue->data[idealindex]->worked = 1;
        int toCompute;
        while (-queue->data[idealindex]->data[0] >= restingTime) {
            toCompute = -queue->data[idealindex]->data[0] - restingTime;
            Queue_DeleteTop(queue->data[idealindex]);
            if (queue->data[idealindex]->size > 0) {
                queue->data[idealindex]->data[0] -= toCompute;
            }
            else {
                break;
            }
        }
        struct Queue* temp;
        temp = PriorityQueue_GetElem(queue, idealindex);
        if ((temp->size > 1) || ((temp->size == 1) && (temp->data[0] > 0))) {
            PriorityQueue_Add(queue, temp);
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

int main() {

    int restTime= 0, workTime= 1;
    int result = 0;
    int n;
    printf("Write a number of nods you would want:\n");
    scanf("%d", &n);
    struct PriorityQueueHead PriorityQueue;
    PriorityQueue_Create(&PriorityQueue);
    printf("Write a priority(p), number of parts(n) and values of parts(value):\n");
    printf("p n value\n");
    for (int i = 0; i < n; i++) {
        int k,prior, tempInput;
        
        scanf("%d%d", &prior, &k);
        struct Queue newQueue;
        Queue_Create(&newQueue, prior);
        for (int j = 0; j < k; j++) {
            scanf("%d", &tempInput);
        
            result += tempInput;
            Queue_Add(&newQueue, tempInput);
        }
        struct Queue* queueToAdd = (struct Queue*)malloc(sizeof(struct Queue));
        memcpy(queueToAdd, &newQueue, sizeof(struct Queue));
        PriorityQueue_Add(&PriorityQueue, queueToAdd);
    }
    //printf("Write a inputTime and Tacttime\n");
    //scanf(" %d %d ", &restTime, &workTime);
    for (int restTime = 0; restTime <= 10; restTime++) {
        for (int workTime = 1; workTime <= 10; workTime++) {


            struct PriorityQueueHead* clonedPriorityQueue = ClonePriorityQueue(&PriorityQueue);
           

            int stage = 0;
            while (clonedPriorityQueue->size != 0) {
                WorkOut(clonedPriorityQueue, workTime, restTime);
                UpdateRestingTime(clonedPriorityQueue, restTime, workTime);
                stage++;
            }


            double eff = 1.0 * result / (stage * workTime) * 100;
            printf("Input time: %d Tact time: %d Tacts amount: %d Efficiency: %f\n", restTime, workTime, stage, eff);

            for (int i = 0; i < clonedPriorityQueue->size; i++) {
                free(clonedPriorityQueue->data[i]->data);
                free(clonedPriorityQueue->data[i]);
            }
            free(clonedPriorityQueue->data);
            free(clonedPriorityQueue);
        }

        printf("%s \n");
  }
    return 0;
}
