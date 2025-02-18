#include <bits/stdc++.h>
using namespace std;

void inicializate_order(queue <int> (&q)[3][3], int priority, int user, int *data, int &_size, int &optimal_time){
    for(int i = 0; i < _size; ++i){
        q[priority][user].push(data[i]);
        optimal_time += data[i];
    }
};

void Andrey(queue <int> (&q)[3][3], int &kol_of_priorities, int (&users)[3], int &optimal_time){
    kol_of_priorities = 3;
    users[0] = 1; users[1] = 3; users[2] = 2;
    int first[] = {4, 2, 3, 4, 6, 8, 9, 3, 2, 1}, first_size = 10;
    int second[] = {4, 2, 6, 8, 7, 3, 1, 2, 4, 6}, second_size = 10;
    int third[] = {2, 3, 4, 5, 9, 7, 6, 8, 3, 2, 2}, thirs_size = 11;
    int fourth[] = {3, 3, 4, 2, 4, 6, 8, 9, 7, 2, 1}, fourth_size = 11;
    int fifth[] = {2, 1, 2, 4, 5, 2, 3, 4, 6, 8, 9}, fifth_size = 11;
    int sixth[] = {1, 2, 1, 6, 1, 9, 8, 1, 6, 8}, sixth_size = 10;
    optimal_time = 0;
    inicializate_order(q, 0, 0, first, first_size, optimal_time);
    inicializate_order(q, 1, 0, second, second_size, optimal_time);
    inicializate_order(q, 1, 1, third, thirs_size, optimal_time);
    inicializate_order(q, 1, 2, fourth, fourth_size, optimal_time);
    inicializate_order(q, 2, 0, fifth, fifth_size, optimal_time);
    inicializate_order(q, 2, 1, sixth, sixth_size, optimal_time);
}

void Dgoni(queue <int> (&q)[3][3], int &kol_of_priorities, int (&users)[3], int &optimal_time){
    kol_of_priorities = 3;
    users[0] = 3; users[1] = 1; users[2] = 2;
    int first[] = {4, 3, 1, 8, 6, 5, 2, 3}, first_size = 8;
    int second[] = {3, 2, 4, 7, 2, 6, 8}, second_size = 7;
    int third[] = {3, 1, 3, 1, 5, 4, 3, 2}, thirs_size = 8;
    int fourth[] = {3, 2, 1, 3, 2, 4, 3}, fourth_size = 7;
    int fifth[] = {1, 2, 1, 4, 2, 6}, fifth_size = 6;
    int sixth[] = {2, 6, 3, 2, 1, 3, 2, 3}, sixth_size = 8;
    optimal_time = 0;
    inicializate_order(q, 0, 0, first, first_size, optimal_time);
    inicializate_order(q, 0, 1, second, second_size, optimal_time);
    inicializate_order(q, 0, 2, third, thirs_size, optimal_time);
    inicializate_order(q, 1, 0, fourth, fourth_size, optimal_time);
    inicializate_order(q, 2, 0, fifth, fifth_size, optimal_time);
    inicializate_order(q, 2, 1, sixth, sixth_size, optimal_time);
}

void Dusya(queue <int> (&q)[3][3], int &kol_of_priorities, int (&users)[3], int &optimal_time){
    kol_of_priorities = 2;
    users[0] = 2; users[1] = 3;
    int first[] = {2, 2, 3, 4, 8, 1, 1, 3, 3, 2}, first_size = 10;
    int second[] = {4, 1, 1, 1, 1, 2, 2, 3, 1, 1}, second_size = 10;
    int third[] = {4, 5, 3, 2, 1, 2, 3, 4, 5}, thirs_size = 9;
    int fourth[] = {4, 5, 3, 2, 1, 1, 3, 3, 8}, fourth_size = 9;
    int fifth[] = {6, 1, 4, 5, 2, 2, 3, 1, 1}, fifth_size = 9;
    optimal_time = 0;
    inicializate_order(q, 0, 0, first, first_size, optimal_time);
    inicializate_order(q, 0, 1, second, second_size, optimal_time);
    inicializate_order(q, 1, 0, third, thirs_size, optimal_time);
    inicializate_order(q, 1, 1, fourth, fourth_size, optimal_time);
    inicializate_order(q, 1, 2, fifth, fifth_size, optimal_time);
}

struct user{
    int priority, index;
};

user find_user(int (&current_user)[3], const char (&busy)[3][3][1000], int &current_sec, queue <int> (&q)[3][3], int &kol_of_priorities, int (&users)[3]){
    user ans;
    ans.priority = ans.index = -1;
    for(int i = 0; i < kol_of_priorities; ++i){
        int prev_user = current_user[i];
        ++current_user[i]; current_user[i] %= users[i];
        for(int j = 0; j < users[i]; ++j) {
            if((!q[i][current_user[i]].empty()) && (busy[i][current_user[i]][current_sec] == 'O')){
                ans.priority = i;
                ans.index = current_user[i];
                return ans;
            }
            ++current_user[i]; current_user[i] %= users[i];
        }
    }
    return ans;
}

bool have_work(queue <int> (&q)[3][3]){
    for(int i = 0; i < 3; ++i)
        for(int j = 0; j < 3; ++j)
            if(!q[i][j].empty())
                return 1;
    return 0;
}

void print_busy(char (&s)[1000], int &hole_time, int &tt){
    for(int i = max(0, hole_time - tt * 4); i < hole_time; ++i){
        cout << s[i] << " ";
        if(i % tt == tt - 1)
            cout << "| ";
    }
    cout << "\n";
    return;
}

void inicializate_busy(char (&a)[3][3][1000]){
    for(int i = 0; i < 3; ++i)
        for(int j = 0; j < 3; ++j)
            for(int k = 0; k < 1000; ++k)
                a[i][j][k] = 'O';
    return;
}

void cout_queue(queue <int> &q){
    if(q.empty()) cout << "-";
    for(int i = 0; i < q.size(); ++i) {
        q.push(q.front());
        cout << q.front() << " ";
        q.pop();
    }
    cout << "\n";
}

int test(int tt, int ti, int &optimal_time, void inicialization(std::queue<int> (&)[3][3], int&, int (&)[3], int&), bool debug){
    queue <int> q[3][3];
    char busy[3][3][1000];
    int users[3];
    int kol_of_priorities;

    inicialization(q, kol_of_priorities, users, optimal_time);
    inicializate_busy(busy);

    bool end_work = 0;
    int current_user[3] = {-1, -1, -1};
    int current_sec = 0;
    int last_add;
    while(!end_work){
        user u = find_user(current_user, busy, current_sec, q, kol_of_priorities, users);
        if(u.priority != -1){
            for(int i = 0; i < min(tt, q[u.priority][u.index].front()); ++i){
                busy[u.priority][u.index][current_sec] = 'L';
                ++current_sec;
            }
            q[u.priority][u.index].push(q[u.priority][u.index].front() - tt); q[u.priority][u.index].pop();
            for(int i = 1; i < q[u.priority][u.index].size(); ++i){
                q[u.priority][u.index].push(q[u.priority][u.index].front());
                q[u.priority][u.index].pop();
            }
            if(q[u.priority][u.index].front() <= 0){
                q[u.priority][u.index].pop();
                for(int i = 0; i < ti; ++i)
                    busy[u.priority][u.index][current_sec + i] = 'B';
            }
            last_add = current_sec % tt ? tt - current_sec % tt : 0;
            current_sec += last_add;
        } else
            current_sec += tt;

        end_work = !have_work(q);
        if(debug){
            for(int i = 0; i < kol_of_priorities; ++i)
                for(int j = 0; j < users[i]; ++j)
                    cout_queue(q[i][j]);
            for(int i = 0; i < kol_of_priorities; ++i)
                for(int j = 0; j < users[i]; ++j)
                    print_busy(busy[i][j], current_sec, tt);
            cout << current_sec << " " << last_add << "\n";
            cout << "\n\n\n";
        }
    }

    return current_sec - last_add;
}

int main(){
    setlocale(LC_ALL, "Russian");

    int optimal_time;

    cout << " \\ti|";
    for(int i = 0; i < 11; ++i)
        cout << "      |"; cout << "\n";
    cout << "tt\\ |";
    for(int i = 0; i < 11; ++i)
        cout << setw(4) << i << "  |"; cout << "\n";
    cout << string(4, '-') << "|";
    for(int i = 0; i < 11; ++i)
        cout << "------|"; cout << "\n";
    for(int tt = 1; tt < 11; ++tt){
        cout << setw(2) << tt << "  | ";
        for(int ti = 0; ti < 11; ++ti){
            cout << setw(4) << test(tt, ti, optimal_time, Dusya, 0) << " | ";
        }
        cout << "\n";
        cout << string(4, '-') << "|";
        for(int i = 0; i < 11; ++i)
            cout << "------|"; cout << "\n";
    }

    cout << "\n\n" << string(81, '-') << "\n";

    cout << " \\ti|";
    for(int i = 0; i < 11; ++i)
        cout << "      |"; cout << "\n";
    cout << "tt\\ |";
    for(int i = 0; i < 11; ++i)
        cout << setw(4) << i << "  |"; cout << "\n";
    cout << string(4, '-') << "|";
    for(int i = 0; i < 11; ++i)
        cout << "------|"; cout << "\n";
    for(int tt = 1; tt < 11; ++tt){
        cout << setw(2) << tt << "  |";
        for(int ti = 0; ti < 11; ++ti){
            int curr_time = test(tt, ti, optimal_time, Dusya, 0);
            cout << fixed << setw(5) << setprecision(1) << 100.0 * optimal_time / curr_time << "%|";
        }
        cout << "\n";
        cout << string(4, '-') << "|";
        for(int i = 0; i < 11; ++i)
            cout << "------|"; cout << "\n";
    }
    return 0;
}
