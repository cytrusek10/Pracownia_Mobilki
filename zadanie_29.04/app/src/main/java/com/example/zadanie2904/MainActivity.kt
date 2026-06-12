package com.example.zadanie2904

import android.os.Bundle
import android.view.Gravity
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    // 15 zdjęć: drawable resource + tytuł
    private val photos = listOf(
        Pair(R.drawable.photo_1,  "Góry"),
        Pair(R.drawable.photo_2,  "Zachód słońca"),
        Pair(R.drawable.photo_3,  "Las"),
        Pair(R.drawable.photo_4,  "Morze"),
        Pair(R.drawable.photo_5,  "Niebo"),
        Pair(R.drawable.photo_6,  "Łąka"),
        Pair(R.drawable.photo_7,  "Park"),
        Pair(R.drawable.photo_8,  "Pustynia"),
        Pair(R.drawable.photo_9,  "Jesień"),
        Pair(R.drawable.photo_10, "Wulkan"),
        Pair(R.drawable.photo_11, "Kanion"),
        Pair(R.drawable.photo_12, "Jezioro"),
        Pair(R.drawable.photo_13, "Ocean"),
        Pair(R.drawable.photo_14, "Wiosna"),
        Pair(R.drawable.photo_15, "Różany ogród")
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        supportActionBar?.title = "Galeria zdjęć"

        val container = findViewById<LinearLayout>(R.id.photoContainer)
        val density   = resources.displayMetrics.density

        for ((resId, title) in photos) {
            // Wrapper: pionowy LinearLayout (obrazek + etykieta)
            val wrapper = LinearLayout(this).apply {
                orientation = LinearLayout.VERTICAL
                gravity     = Gravity.CENTER_HORIZONTAL
                layoutParams = LinearLayout.LayoutParams(
                    (160 * density).toInt(),
                    LinearLayout.LayoutParams.MATCH_PARENT
                ).apply {
                    marginEnd = (12 * density).toInt()
                }
            }

            // ImageView
            val imageView = ImageView(this).apply {
                setImageResource(resId)
                scaleType    = ImageView.ScaleType.CENTER_CROP
                layoutParams = LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MATCH_PARENT,
                    0,
                    1f
                )
                // Zaokrąglone rogi przez background
                clipToOutline = true
                contentDescription = title

                // Kliknięcie -> DialogFragment
                setOnClickListener {
                    val dialog = ImageDialogFragment.newInstance(resId, title)
                    dialog.show(supportFragmentManager, "image_dialog")
                }
            }

            // Etykieta pod zdjęciem
            val label = TextView(this).apply {
                text      = title
                textSize  = 11f
                gravity   = Gravity.CENTER
                setTextColor(0xFFCCCCCC.toInt())
                setPadding(4, 6, 4, 0)
                layoutParams = LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MATCH_PARENT,
                    LinearLayout.LayoutParams.WRAP_CONTENT
                )
            }

            wrapper.addView(imageView)
            wrapper.addView(label)
            container.addView(wrapper)
        }
    }
}
