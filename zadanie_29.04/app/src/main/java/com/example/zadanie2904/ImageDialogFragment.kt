package com.example.zadanie2904

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.fragment.app.DialogFragment

class ImageDialogFragment : DialogFragment() {

    companion object {
        private const val ARG_IMAGE_RES = "image_res"
        private const val ARG_IMAGE_TITLE = "image_title"

        fun newInstance(imageRes: Int, title: String): ImageDialogFragment {
            return ImageDialogFragment().apply {
                arguments = Bundle().apply {
                    putInt(ARG_IMAGE_RES, imageRes)
                    putString(ARG_IMAGE_TITLE, title)
                }
            }
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_image_dialog, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val imageRes   = arguments?.getInt(ARG_IMAGE_RES) ?: return
        val imageTitle = arguments?.getString(ARG_IMAGE_TITLE) ?: ""

        view.findViewById<TextView>(R.id.dialogTitle).text = imageTitle
        view.findViewById<ImageView>(R.id.dialogImage).setImageResource(imageRes)

        view.findViewById<Button>(R.id.btnClose).setOnClickListener {
            dismiss()
        }
    }

    override fun onStart() {
        super.onStart()
        // Ustaw szerokość dialogu na 90% ekranu
        dialog?.window?.setLayout(
            (resources.displayMetrics.widthPixels * 0.9).toInt(),
            ViewGroup.LayoutParams.WRAP_CONTENT
        )
    }
}
