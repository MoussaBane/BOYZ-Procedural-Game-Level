import numpy as np
import matplotlib.pyplot as plt
from scipy.ndimage import label

# Parametreler
GRID_SIZE = 10  # Oyun alanının boyutu
EMPTY = 0  # Boş alan
START = 1  # Başlangıç noktası
GOAL = 2  # Hedef noktası
OBSTACLE = 3  # Engel

# Kural Tabanlı Yaklaşım
def rule_based_generation(grid_size):
    grid = np.zeros((grid_size, grid_size), dtype=int)

    # Başlangıç ve hedef noktaları
    grid[0, 0] = START
    grid[grid_size - 1, grid_size - 1] = GOAL

    # Engel ekleme kuralları (örnek: geçilebilir bir yol garantisi)
    num_obstacles = (grid_size * grid_size) // 4
    for _ in range(num_obstacles):
        x, y = np.random.randint(0, grid_size, size=2)
        if grid[x, y] == EMPTY:
            grid[x, y] = OBSTACLE

    # Geçerli bir yol oluşturma (basit bir örnek: köşegen yol)
    for i in range(grid_size):
        if grid[i, i] == OBSTACLE:
            grid[i, i] = EMPTY

    return grid

# Derin Öğrenme Yaklaşımı (Simüle edilmiş GAN)
def simulated_gan_generation(grid_size):
    grid = np.random.choice([EMPTY, OBSTACLE], size=(grid_size, grid_size), p=[0.7, 0.3])

    # Başlangıç ve hedef noktalarını sabitle
    grid[0, 0] = START
    grid[grid_size - 1, grid_size - 1] = GOAL

    # Geçerli bir yol oluşturma (örnek: rastgele bir bağlantı)
    x, y = 0, 0
    while (x, y) != (grid_size - 1, grid_size - 1):
        grid[x, y] = EMPTY
        if np.random.rand() > 0.5 and x < grid_size - 1:
            x += 1
        elif y < grid_size - 1:
            y += 1
        grid[x, y] = EMPTY

    return grid

# Oyun seviyelerini görselleştirme
def visualize_grid(grid, title):
    plt.figure(figsize=(6, 6))
    plt.imshow(grid, cmap="tab20c", origin="upper")
    plt.title(title)
    plt.xticks([])
    plt.yticks([])
    plt.colorbar(ticks=[EMPTY, START, GOAL, OBSTACLE], label="Legend")
    plt.show()

# Geçerli bir yol olup olmadığını kontrol etme
def check_valid_path(grid):
    labeled_grid, num_features = label(grid != OBSTACLE)
    start_label = labeled_grid[0, 0]
    goal_label = labeled_grid[GRID_SIZE - 1, GRID_SIZE - 1]
    return start_label == goal_label and start_label != 0

# Kural tabanlı seviye üretimi
rule_based_grid = rule_based_generation(GRID_SIZE)
visualize_grid(rule_based_grid, "Rule-Based Level Generation")
if check_valid_path(rule_based_grid):
    print("Kural tabanlı yöntemde geçerli bir yol var!")
else:
    print("Kural tabanlı yöntemde geçerli bir yol yok!")

# Simüle edilmiş GAN seviye üretimi
gan_based_grid = simulated_gan_generation(GRID_SIZE)
visualize_grid(gan_based_grid, "Simulated GAN-Based Level Generation")
if check_valid_path(gan_based_grid):
    print("Simüle edilmiş GAN yönteminde geçerli bir yol var!")
else:
    print("Simüle edilmiş GAN yönteminde geçerli bir yol yok!")