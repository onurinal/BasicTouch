# Interaction System - [Onur İnal]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.0.23f1 |
| Render Pipeline | Built-in / URP |
| Case Süresi | 12 saat |
| Tamamlanma Oranı | %50 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/onurinal/BasicTouch.git
```

2. Unity Hub'da projeyi açın
3. `Assets/BasicTouch/Scenes/Gameplay.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |

### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press to open door" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

---

## Mimari Kararlar

### Interaction System Yapısı

```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> Interface yapısını kullanarak mimariyi oluşturdum. Bu yapıyı kullanmamın sebebi daha modular, daha scalable olması. İleride herhangi bir interactable obje eklenmesi gerektiğinde IInteractable interface türlerinden bir tanesini kalıtım alarak basit bir şekilde interactable olduğunu belirtmiş oluyoruz. Böylece player etkileşime girdiğinde bunun hangi class olduğunu bilmesine gerek kalmadan bu objenin etkileşime girebilen bir obje olduğunu bilmesi yeterli oluyor.

**Alternatifler:**
> Interface mimarisi dışında aklıma şimdilik abstract base class geldi. Abstract ile interaction bir base class oluşturup ardından door, key gibi itemler bu abstract class'ı kalıtım alıp interactable item olduklarını anlayabiliriz. Interface kullanarak interaction mimarisi yapmak çok daha kolay olduğunu düşündüğümden bunu kullanmadım.

**Trade-off'lar:**
> Projeyi yaparken zamanım kalmadığı için trade off' un açıkçası ne olduğunu bilmiyordum. README kısmını güncelledikten sonra ne olduğunu öğreneceğim.

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Basit bir EventManager sistemi kullandım, scriptler arası bağımlılıkları azaltmak için.]
| [State - Enum Based] | [Door states] | [State pattern basit hali. Bir Enum ile Locked/Unlocked state ekledim. Bool değişkeni yeterli olsa da ileride başka stateler eklenmesi gerektiğinde Enum ile daha rahat kontrol edebiliriz. ]
| [Singleton] | [UI Manager] | [Case süresi az kaldığından singleton'a başvurmak zorunda kaldım. Daha hızlı ve daha kolay erişebilmek adına yoksa elimden geldiğince kullanmamaya çalışırım.]

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [] / [x] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_LockedDoor1, P_Player |
| M_ prefix (Material) | [x] / [ ] | M_Ground, M_LockedDoor1 |
| T_ prefix (Texture) | [] / [x] | Texture kullanılmadı. |
| SO isimlendirme | [] / [x] | Daha fazla sürem kalmadığından SO isimlendirmesine bakamadım. |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Genellikle box collider kullanıldı fakat anahtar ve interaction range için sphere collider kullandım. Sürem yetmediğinden buralarda düzenlemeye gidemedim. |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

açıkçası ilk başta dökümanları okurken baya zaman kaybettim diyebilirim. Ardından daha fazla zaman kaybetmemek adına aklıam gelen en basit yapıları eklemeye çalışırken door interaction sistemini ekledikten sonra ve anahtar ekleme kısmına gelince neredeyse zamanımın kalmadığını anladım. 

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [] / [x] Switch/Lever
  - [] / [x] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [] / [x] Hold progress bar
  - [] / [x] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [] / [x] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Switch/Lever Interaction] - [Sürem yetmedi. Prefab veya kendi sistemini yazacak kadar vaktim kalmadı maalesef.]
2. [Chest/Container Interaction] - [Aynı şekilde sürem yetmedi.]

### Bilinen Bug'lar
1. Not: Herhangi bir bug ile test ettiğim süre boyunca karşılaşmadım.

### İyileştirme Önerileri
1. [Player Inventory] - [Çok daha iyi yazılabilirdi, sırf daha hızlı bitirebilmek, ufak da olsa öyle bir küçük info elimde tutabileyim diye scriptable object olarak açmıştım ve Door.cs, Key.cs gibi classların player inventory e bağımlı olmaması gerekiyor. Çok daha farklı bir şekilde player inventory den bilgi ya da player inventory ve door ile bağlantıyı kurabilecek fazladan bir script yapılabilirdi. Bu itemleri tutan listeyi public static tarzında bir class ulaştırabilirdi mesela, şimdilik aklıma gelen bu. ]
2. [Animasyonlar] - Animasyonlar çok basit şekilde eklendi ve daha iyi yapılabilirdi. Ses vs. eklenebilirdi.
3. [UI] - Interaction text için ortada değil de en altta göstermek istiyordum zamanım yetmedi. Ek olarak locked door için eğer ki player anahtara sahip değilse texte bir animasyon verip kullanıcının dikkatini çekecek şekilde yapılabilirdi, daha hoş gözükmesi adına. Son olarak eklediğim objelerin hiçbirinde herhangi bir texture vs. yok. Bu konuda internetten free model, texture vs. bulup projeye eklenebilirdi.

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:
---

## Dosya Yapısı

```
Assets/
├── [BasicTouch]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── DoorLockState.cs
│   │   │   │   └── IInteractable.cs
│   │   │   │   └── IInteractableHold.cs
│   │   │   │   └── IInteractableInstant.cs
│   │   │   │   └── IInteractableToggle.cs
│   │   │   │   └── ItemProperties.cs
│   │   │   ├── Event/
│   │   │   │   ├── EventManager.cs
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── Key.cs
│   │   │   ├── Player/
│   │   │   │   └── PlayerController.cs
│   │   │   │   └── PlayerInputHandler.cs
│   │   │   │   └── PlayerInteractionDetector.cs
│   │   │   │   └── PlayerInventory.cs
│   │   │   │   └── PlayerProperties.cs
│   │   │   └── UI/
│   │   │       └── UIManager.cs
│   │   └── Editor/
│   ├── ScriptableObjects/
│       └── Key_1.asset
│       └── Key_2.asset
│       └── PlayerData.asset
│       └── PlayerInventory.asset
│   ├── Prefabs/
│       └── P_LockedDoor_1.prefab
│       └── P_LockedDoor_2.prefab
│       └── P_Player.prefab
│       └── P_UnlockedDoor.prefab
│       └── Key_1.prefab
│       └── Key_2.prefab
│   ├── Materials/
│       └── M_Ground.mat
│       └── M_Key_1.mat
│       └── M_Key_2.mat
│       └── M_LockedDoor1.mat
│       └── M_LockedDoor2.mat
│       └── M_Player.mat
│       └── M_UnlockedDoor.mat
│   └── Scenes/
│       └── Gameplay.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Onur İnal] |
| E-posta | [onurinaldev@gmail.com] |
| LinkedIn | [https://www.linkedin.com/in/onurinall] |
| GitHub | [https://github.com/onurinal] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
